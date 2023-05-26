using WebApiTest.Application.Common.Exceptions;
using WebApiTest.Application.Common.Interfaces;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Acontecimientos.Interfaces;
using WebApiTest.Application.Features.Acontecimientos.Specifications;
using WebApiTest.Domain.Entities.Acontecimientos;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Acontecimientos.Commands.DeleteLogicoAcontecimientos
{
    /*
    public record DeleteLogicoAcontecimientoCommand(int idAcontecimiento) : IRequest<ResponseType<string>>;
    public class DeleteLogicoAcontecimientoCommandQuery : IRequestHandler<DeleteLogicoAcontecimientoCommand, ResponseType<string>>
    {
        private readonly IConfiguration _config;

        private readonly IApisConsumoAsync _repositoryApis;
        private readonly IRepositoryAsync<AcontecimientosModels> _repoAcont;

        public DeleteLogicoAcontecimientoCommandQuery(IRepositoryAsync<AcontecimientosModels> repoAcont, IConfiguration config, IApisConsumoAsync repositoryApis)
        {
            _config = config;
            _repositoryApis = repositoryApis;
            _repoAcont = repoAcont;
        }

        public async Task<ResponseType<string>> Handle(DeleteLogicoAcontecimientoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pbjAcontecimiento = await _repoAcont.FirstOrDefaultAsync(new AcontecimientosByIdSpec(request.idAcontecimiento), cancellationToken);

                if (pbjAcontecimiento is null)
                {
                    return new ResponseType<string>() { Succeeded = false, Data = null, Message = CodeMessageResponse.GetMessageByCode("201", "No existe registro para actualizar"), StatusCode = "201" };
                }

                if (pbjAcontecimiento is not null)
                {

                    var objActualizar = new
                    {
                        idAcontecimiento = request.idAcontecimiento,
                        Estado = false
                    };

                    var objData1 = await _repositoryApis.PutEndPoint(objActualizar);

                }



                return new ResponseType<string>() { Succeeded = true, Data = null, Message = CodeMessageResponse.GetMessageByCode("200", "La solicitud ha sido "), StatusCode = "200" };
            }
            catch (Exception ex)
            {
                return new ResponseType<string>() { Succeeded = false, Data = null, Message = CodeMessageResponse.GetMessageByCode("201"), StatusCode = "201" };
            }
        }
    }
    */
    
    public record DeleteLogicoAcontecimientoCommand(int idAcontecimiento, int idEvento, string NombreEvento, DateTime Fecha, string Lugar, int NumeroEntrada, string Descripcion, int Precio) : IRequest<ResponseType<string>>;
    public class DeleteLogicoAcontecimientoCommandQuery : IRequestHandler<DeleteLogicoAcontecimientoCommand, ResponseType<string>>
    {

        private readonly IAcontecimientos _repositoryAcontecimiento;

        public DeleteLogicoAcontecimientoCommandQuery(
           IAcontecimientos acontecimientos)
        {
            _repositoryAcontecimiento = acontecimientos;
        }

        public async Task<ResponseType<string>> Handle(DeleteLogicoAcontecimientoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AcontecimientosModels acontecimientos = new AcontecimientosModels()
                {
                    Descripcion = request.Descripcion,
                    Fecha = request.Fecha,
                    idAcontecimiento = request.idAcontecimiento,
                    idEvento = request.idEvento,
                    Lugar = request.Lugar,
                    NumeroEntrada = request.NumeroEntrada,
                    Precio = request.Precio,
                    nombreEvento = request.NombreEvento,
                    Estado = false
                };

                var objData1 = await _repositoryAcontecimiento.DeleteLogicoAcontecimiento(acontecimientos, cancellationToken);



                return new ResponseType<string>() { Succeeded = true, Data = null, Message = CodeMessageResponse.GetMessageByCode("200", "El registro ha sido "), StatusCode = "200" };
            }
            catch (Exception)
            {
                return new ResponseType<string>() { Succeeded = false, Data = null, Message = CodeMessageResponse.GetMessageByCode("201"), StatusCode = "201" };
            }
        }
    }
}
