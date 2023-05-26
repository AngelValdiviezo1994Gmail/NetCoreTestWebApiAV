/*
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Common.Exceptions;
using WebApiTest.Application.Common.Interfaces;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Dto;
using WebApiTest.Application.Features.Adjunto.Interfaces;
using WebApiTest.Application.Features.Adjunto.Specifications;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Persistence.Repository
{
    internal class AdjuntoService
    {
    }
}
*/

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WebApiTest.Application.Common.Exceptions;
using WebApiTest.Application.Common.Interfaces;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto;
using WebApiTest.Application.Features.Adjunto.Dto;
using WebApiTest.Application.Features.Adjunto.Interfaces;
using WebApiTest.Application.Features.Adjunto.Specifications;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Persistence.Repository
{
    public class AdjuntoService : IAdjuntoService
    {
        private const string _User = "admin";
        
        
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<Adjuntos> _log;
        private readonly IRepositoryAsync<Adjuntos> _repoAjuntoAsync;

        public AdjuntoService(IConfiguration config, IRepositoryAsync<Adjuntos> repository, IMapper mapper, ILogger<Adjuntos> log)
        {
            _repoAjuntoAsync = repository;
            
            _mapper = mapper;
            _config = config;
            _log = log;
            
        }

        /*
         
        private readonly IRepositoryAsync<AcontecimientosModels> _repositoryAcontecimientoAsync;

        public AcontecimientoService(IRepositoryAsync<AcontecimientosModels> repositoryAcontecimientoAsync)
        {
            _repositoryAcontecimientoAsync = repositoryAcontecimientoAsync;
        }
         
         */


        #region ProcesarAdjunto
        //ProcesarAdjuntoRequest
        //public async Task<ResponseType<string>> ProcesarAdjunto(Adjuntos request, CancellationToken cancellationToken)
        public async Task<ResponseType<string>> ProcesarAdjunto(ProcesarAdjuntoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string rutaAdjuntoBase = _config.GetSection("Adjuntos:RutaBase").Get<string>();
                string rutaComplemento = "";

                if (!string.IsNullOrEmpty(request.IdFeature))
                {
                    rutaComplemento = ProcesaRuta(request.IdFeature, request.Categoria);
                }

                string nombreArchivo = request.NombreArchivo.Split('.')[0] + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".";
                string extensionArchivo = request.NombreArchivo[(request.NombreArchivo.LastIndexOf(".") + 1)..];

                var tmpruta = string.Concat(rutaAdjuntoBase, rutaComplemento);
                var tmpfinal = string.Concat(rutaAdjuntoBase, rutaComplemento, nombreArchivo, extensionArchivo);
                //var objClient = _mapper.Map<Adjuntos>(request);
                Adjuntos objClient = new Adjuntos();

                string rutaPath = Path.Combine(tmpruta);
                string finalPath = Path.Combine(tmpfinal);

                if (!Directory.Exists(rutaPath))
                {
                    Directory.CreateDirectory(rutaPath);
                }

                string base64String = request.ArchivoBase64;
                byte[] imgBytes = Convert.FromBase64String(base64String);
                using var docFile = new FileStream(finalPath, FileMode.Create);
                docFile.Write(imgBytes, 0, imgBytes.Length);
                docFile.Flush();

                objClient.RutaAcceso = finalPath;
                objClient.Id = Guid.NewGuid();
                objClient.Identificacion = request.Identificacion;
                objClient.UsuarioCreacion = _User;
                objClient.NombreArchivo = nombreArchivo + extensionArchivo;
                objClient.IdSolicitud = request.IdSolicitud ?? string.Empty;
                objClient.IdTipoSolicitud = request.IdTipoSolicitud ?? string.Empty;
                objClient.IdFeature = request.IdFeature ?? string.Empty;
                objClient.Estado = "A";

                //var objResultado = await _repositoryAcontecimientoAsync.AddAsync(objAcont, cancellationToken);

                var insAdjunto = await _repoAjuntoAsync.AddAsync(objClient, cancellationToken);

                if (insAdjunto is not null)
                {
                    return new ResponseType<string>() { Data = insAdjunto.Id.ToString(), StatusCode = "100", Message = CodeMessageResponse.GetMessageByCode("100", "Adjunto"), Succeeded = true };
                }
                else
                {
                    return new ResponseType<string>() { Data = null, StatusCode = "101", Message = CodeMessageResponse.GetMessageByCode("101", "Adjunto"), Succeeded = true };
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, string.Empty);
                return new ResponseType<string>() { Data = null, StatusCode = "102", Message = CodeMessageResponse.GetMessageByCode("102"), Succeeded = false };
            }
        }
        #endregion

        #region NewProcesarAdjunto
        public async Task<ResponseType<string>> NewProcesarAdjunto(List<Adjuntos> request, CancellationToken cancellationToken)
        {
            try
            {
                string rutaAdjuntoBase = _config.GetSection("Adjuntos:RutaBase").Get<string>();

                foreach (Adjuntos ad in request)
                {
                    string rutaComplemento = string.Empty;

                    if (!string.IsNullOrEmpty(ad.IdFeature))
                        rutaComplemento = ProcesaRuta(ad.IdFeature, ad.Categoria);

                    string nombreArchivo = string.Concat(ad.NombreArchivo, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                    string extensionArchivo = ad.ExtensionArchivo;

                    string rutaPath = string.Concat(rutaAdjuntoBase, rutaComplemento);
                    string finalPath = string.Concat(rutaAdjuntoBase, rutaComplemento, nombreArchivo, extensionArchivo);
                    var objClient = _mapper.Map<Adjuntos>(ad);

                    if (!Directory.Exists(rutaPath))
                        Directory.CreateDirectory(rutaPath);

                    byte[] archivoByte = ad.ArchivoByte;
                    using var docFile = new FileStream(finalPath, FileMode.Create);
                    docFile.Write(archivoByte, 0, archivoByte.Length);
                    docFile.Flush();

                    objClient.RutaAcceso = finalPath;
                    objClient.Id = Guid.NewGuid();
                    objClient.Identificacion = ad.Identificacion;
                    objClient.UsuarioCreacion = _User;
                    objClient.NombreArchivo = nombreArchivo + extensionArchivo;
                    objClient.IdSolicitud = ad.IdSolicitud ?? string.Empty;
                    objClient.IdTipoSolicitud = ad.IdTipoSolicitud ?? string.Empty;
                    objClient.IdFeature = ad.IdFeature ?? string.Empty;
                    objClient.Estado = "A";

                    await _repoAjuntoAsync.AddAsync(objClient, cancellationToken);
                }

                return new ResponseType<string>() { Data = null, StatusCode = "100", Message = CodeMessageResponse.GetMessageByCode("100", "Adjunto"), Succeeded = true };
            }
            catch (Exception ex)
            {
                _log.LogError(ex, string.Empty);
                return new ResponseType<string>() { Data = null, StatusCode = "500", Message = CodeMessageResponse.GetMessageByCode("500"), Succeeded = false };
            }
        }
        #endregion


        #region GetAdjunto

        public async Task<ResponseType<List<AdjuntoType>>> GetAdjunto(string identificacion, string idFeature, string idSolicitud, CancellationToken cancellationToken)
        {
            try
            {
                var adjunto_ = await _repoAjuntoAsync.ListAsync(new AdjuntoByIdentifiacionAndFeatureSpec(identificacion, idFeature, idSolicitud), cancellationToken);

                if (adjunto_.Any())
                {
                    return await Task.FromResult(new ResponseType<List<AdjuntoType>>() { Succeeded = true, Message = CodeMessageResponse.GetMessageByCode("000"), StatusCode = "000", Data = _mapper.Map<List<AdjuntoType>>(adjunto_) });
                }

                return await Task.FromResult(new ResponseType<List<AdjuntoType>>() { Succeeded = true, Message = CodeMessageResponse.GetMessageByCode("001"), StatusCode = "001" });
            }
            catch (Exception ex)
            {
                _log.LogError(ex, string.Empty);
                return new ResponseType<List<AdjuntoType>>() { Succeeded = false, Message = CodeMessageResponse.GetMessageByCode("002"), StatusCode = "002" };
            }
        }

        #endregion


        #region GetAdjuntoWallet
        public async Task<ResponseType<List<AdjuntoTypeWallet>>> GetAdjuntoWallet(string identificacion, string idfeature, CancellationToken cancellationToken)
        {
            try
            {
                var adjunto_ = await _repoAjuntoAsync.ListAsync(new AdjuntoByIdentifiacionAndFeatureSpec(identificacion, idfeature, string.Empty), cancellationToken);

                if (!adjunto_.Any())
                {
                    return await Task.FromResult(new ResponseType<List<AdjuntoTypeWallet>>() { Succeeded = true, Message = CodeMessageResponse.GetMessageByCode("001"), StatusCode = "001", Data = null });
                }

                foreach (var itemAdjunto in adjunto_)
                {
                    string categoria = itemAdjunto.RutaAcceso.Split('/')[(itemAdjunto.RutaAcceso.Split('/').Length + -3)];

                    if (categoria == "fotos")
                    {
                        itemAdjunto.Categoria = 1;
                    }
                    else if (categoria == "documentos")
                    {
                        itemAdjunto.Categoria = 2;
                    }
                    else if (categoria == "cupones")
                    {
                        itemAdjunto.Categoria = 3;
                    }
                    else if (categoria == "tarjetero")
                    {
                        itemAdjunto.Categoria = 4;
                    }
                    else if (categoria == "otros-documentos")
                    {
                        itemAdjunto.Categoria = 5;
                    }
                }

                return await Task.FromResult(new ResponseType<List<AdjuntoTypeWallet>>() { Succeeded = true, Message = CodeMessageResponse.GetMessageByCode("000"), StatusCode = "000", Data = _mapper.Map<List<AdjuntoTypeWallet>>(adjunto_) });

            }
            catch (Exception ex)
            {
                _log.LogError(ex, string.Empty);
                return await Task.FromResult((new ResponseType<List<AdjuntoTypeWallet>>() { Succeeded = false, Message = CodeMessageResponse.GetMessageByCode("002"), StatusCode = "002" }));
            }
        }
        #endregion

        #region UpdateAdjunto

        public async Task<ResponseType<string>> UpdateAdjunto(string adjuntoId, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repoAjuntoAsync.GetByIdAsync(Guid.Parse(adjuntoId), cancellationToken);

                entity.Estado = "I";

                await _repoAjuntoAsync.UpdateAsync(entity, cancellationToken);

                return await Task.FromResult(new ResponseType<string>() { Succeeded = true, Message = CodeMessageResponse.GetMessageByCode("200", "Adjunto"), StatusCode = "200", Data = null });

            }
            catch (Exception ex)
            {
                _log.LogError(ex, string.Empty);
                return await Task.FromResult((new ResponseType<string>() { Succeeded = false, Message = CodeMessageResponse.GetMessageByCode("201"), StatusCode = "201" }));
            }
        }



        #endregion



        #region ProcesaRuta

        private static string ProcesaRuta(string idFeature, int categoria)
        {
            const string featVacacion = "26A08EC8-40FE-435C-8655-3F570278879E";
            const string featCredencial = "AFE27CF6-C3E6-4363-9D52-42C1FF627F28";
            const string featPermiso = "DE4D17BD-9F03-4CCB-A3C0-3F37629CEA6A";
            const string featJustificacion = "1939EA3E-AA62-487E-87F0-2B07017AC586";
            const string featWallet = "5499AD75-DB44-4CD5-9C9F-13FE85B86087";

            string retorno = "";

            switch (idFeature)
            {
                case featVacacion:
                    retorno = "tramites/vacacion/" + DateTime.Now.ToString("MM") + "/";
                    break;

                case featCredencial:
                    retorno = "usuarios/perfil/" + DateTime.Now.ToString("MM") + "/";
                    break;

                case featPermiso:
                    retorno = "tramites/permiso/" + DateTime.Now.ToString("MM") + "/";
                    break;

                case featJustificacion:
                    retorno = "tramites/justificacion/" + DateTime.Now.ToString("MM") + "/";
                    break;

                case featWallet:
                    if (categoria == 1)
                    {
                        retorno = "usuarios/wallet/fotos/" + DateTime.Now.ToString("MM") + "/";
                    }
                    else if (categoria == 2)
                    {
                        retorno = "usuarios/wallet/documentos/" + DateTime.Now.ToString("MM") + "/";
                    }
                    else if (categoria == 3)
                    {
                        retorno = "usuarios/wallet/cupones/" + DateTime.Now.ToString("MM") + "/";
                    }
                    else if (categoria == 4)
                    {
                        retorno = "usuarios/wallet/tarjetero/" + DateTime.Now.ToString("MM") + "/";
                    }
                    else if (categoria == 5)
                    {
                        retorno = "usuarios/wallet/otros-documentos/" + DateTime.Now.ToString("MM") + "/";
                    }
                    break;

                default:
                    break;
            }
            return retorno;
        }

        #endregion

    }

}