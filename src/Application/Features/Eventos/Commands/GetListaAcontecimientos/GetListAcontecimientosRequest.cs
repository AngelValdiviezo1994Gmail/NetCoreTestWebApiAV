using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Eventos.Commands.GetListaAcontecimientos
{
    public class GetListAcontecimientosRequest
    {
        public int idEvento { get; set; }
        public int idAcontecimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int NumeroEntrada { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
    }
}
