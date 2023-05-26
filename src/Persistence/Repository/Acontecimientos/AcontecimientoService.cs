using WebApiTest.Application.Common.Exceptions;
using WebApiTest.Application.Common.Interfaces;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using WebApiTest.Application.Features.Acontecimientos.Dto;
using WebApiTest.Application.Features.Acontecimientos.Interfaces;
using WebApiTest.Domain.Entities.Acontecimientos;
using WebApiTest.Domain.Entities.Eventos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Persistence.Repository.Acontecimientos
{
    public class AcontecimientoService : IAcontecimientos
    {
        private readonly IRepositoryAsync<AcontecimientosModels> _repositoryAcontecimientoAsync;

        public AcontecimientoService(IRepositoryAsync<AcontecimientosModels> repositoryAcontecimientoAsync)
        {
            _repositoryAcontecimientoAsync = repositoryAcontecimientoAsync;
        }

        public async Task<ResponseType<string>> CreateAcontecimiento(CreateAcontecimientosRequest Request, CancellationToken cancellationToken)
        {
            try
            {
                var marcacionColaborador = DateTime.Now;
                AcontecimientosResponseType objResultFinal = new();

                AcontecimientosModels objAcont = new()
                {
                    idEvento = Request.IdEvento,
                    nombreEvento = Request.NombreEvento,
                    Descripcion = Request.Descripcion,
                    Fecha = Request.Fecha,
                    Lugar= Request.Lugar,
                    NumeroEntrada = Request.NumeroEntrada,
                    Precio = Request.Precio,
                    Estado = true
                };

                var objResultado = await _repositoryAcontecimientoAsync.AddAsync(objAcont, cancellationToken);
                if (objResultado is null)
                {
                    return new ResponseType<string>() { Message = "No se ha podido registrar su información", StatusCode = "101", Succeeded = true };
                }

                return new ResponseType<string>() { Data = null, Message = "Registro ingresado correctamente", StatusCode = "100", Succeeded = true };

            }
            catch (Exception ex)
            {
                return new ResponseType<string>() { Message = CodeMessageResponse.GetMessageByCode("102"), StatusCode = "102", Succeeded = false };
            }


        }


        public async Task<ResponseType<string>> UpdateAcontecimiento(AcontecimientosModels Request, CancellationToken cancellationToken)
        {
            try
            {
                await _repositoryAcontecimientoAsync.UpdateAsync(Request, cancellationToken);
                

                return new ResponseType<string>() { Data = null, Message = "Registro ingresado correctamente", StatusCode = "100", Succeeded = true };

            }
            catch (Exception ex)
            {
                return new ResponseType<string>() { Message = CodeMessageResponse.GetMessageByCode("102"), StatusCode = "102", Succeeded = false };
            }


        }

        public async Task<ResponseType<string>> DeleteLogicoAcontecimiento(AcontecimientosModels Request, CancellationToken cancellationToken)
        {
            try
            {
                await _repositoryAcontecimientoAsync.UpdateAsync(Request, cancellationToken);


                return new ResponseType<string>() { Data = null, Message = "Registro ingresado correctamente", StatusCode = "100", Succeeded = true };

            }
            catch (Exception ex)
            {
                return new ResponseType<string>() { Message = CodeMessageResponse.GetMessageByCode("102"), StatusCode = "102", Succeeded = false };
            }


        }

    }
}
