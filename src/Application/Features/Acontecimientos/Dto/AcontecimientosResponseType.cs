using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Acontecimientos.Dto
{
    public class AcontecimientosResponseType
    {
        /*
        [JsonPropertyName("marcacionId")]
        public int MarcacionId { get; set; }

        [JsonPropertyName("tipoMarcacion")]
        public string TipoMarcacion { get; set; }
        */

        [JsonPropertyName("mensajeRespuesta")]
        public string MensajeRespuesta { get; set; }
    }
}
