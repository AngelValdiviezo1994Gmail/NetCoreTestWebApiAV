using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Adjunto.Dto
{
    public class AdjuntoTypeWallet
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("categoria")]
        public int Categoria { get; set; }

        [JsonPropertyName("nombreImagen")]
        public string NombreArchivo { get; set; }

        [JsonPropertyName("rutaAcceso")]
        public string RutaAcceso { get; set; } = string.Empty;

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
    }
}
