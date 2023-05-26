using WebApiTest.Application.Common.Exceptions;
using WebApiTest.Application.Common.Interfaces;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Eventos.Dto;
using WebApiTest.Application.Features.Eventos.Specifications;
using WebApiTest.Domain.Entities.Eventos;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Eventos.Commands.GetListaEventos
{
    public record GetListEventosCommand() : IRequest<ResponseType<List<EventosType>>>;

    public class GetListEventosCommandHandler : IRequestHandler<GetListEventosCommand, ResponseType<List<EventosType>>>
    {
        private readonly IRepositoryAsync<tblEventoNextTi> _repositoryEventosAsync;

        public GetListEventosCommandHandler(IRepositoryAsync<tblEventoNextTi> repositoryEvAsync)
        {
            _repositoryEventosAsync = repositoryEvAsync;
        }

        public async Task<ResponseType<List<EventosType>>> Handle(GetListEventosCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await  _repositoryEventosAsync.ListAsync(new GetListEventsConvivenciaSpec(), cancellationToken);

                if (!data.Any())
                {
                    return new ResponseType<List<EventosType>>() { Data = null, Message = "No existen registros en base", StatusCode = "001", Succeeded = false };
                }


                var response = ProcesoListadoEventos(data);

                return new ResponseType<List<EventosType>>() { Data = response, Message = CodeMessageResponse.GetMessageByCode("000"), StatusCode = "000", Succeeded = true };

            }
            catch (Exception)
            {
                return new ResponseType<List<EventosType>>() { Data = null, Message = CodeMessageResponse.GetMessageByCode("500"), StatusCode = "500", Succeeded = false };
            }
        }

        public static List<EventosType> ProcesoListadoEventos(List<tblEventoNextTi> lstEventos)
        {
            var res = new List<EventosType>();

            foreach (var objEvento in lstEventos)
            {
                res.Add(new()
                {
                    idEvento = objEvento.idEvento,
                    nombreEvento = objEvento.nombreEvento
                }
                 );
            }


            res = res.OrderBy(x => x.idEvento).ToList();

            return res;
        }

    }

}
