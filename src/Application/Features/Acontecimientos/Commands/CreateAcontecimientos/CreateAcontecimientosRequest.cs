using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Acontecimientos.Commands.CreateAcontecimientos
{
    public class CreateAcontecimientosRequest
    {
        [JsonPropertyName("idEvento")]
        public int IdEvento { get; set; }

        [JsonPropertyName("Fecha")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("nombreEvento")]
        public string NombreEvento { get; set; }

        [JsonPropertyName("Lugar")]
        public string Lugar { get; set; }

        [JsonPropertyName("NumeroEntrada")]
        public int NumeroEntrada { get; set; }

        [JsonPropertyName("Descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("Precio")]
        public int Precio { get; set; }
    }
}
