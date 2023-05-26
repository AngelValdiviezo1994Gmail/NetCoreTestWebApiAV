using WebApiTest.Domain.Entities.Eventos;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Eventos.Specifications
{
    public class GetListEventsConvivenciaSpec : Specification<tblEventoNextTi>
    {
        public GetListEventsConvivenciaSpec()
        {
            Query.OrderBy(x => x.idEvento);
        }
    }
}
