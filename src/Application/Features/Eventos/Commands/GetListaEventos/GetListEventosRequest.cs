using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Eventos.Commands.GetListaEventos
{
    public class GetListEventosRequest
    {
        public int idEvento { get; set; }
        public string nombreEvento { get; set; }
    }
}
