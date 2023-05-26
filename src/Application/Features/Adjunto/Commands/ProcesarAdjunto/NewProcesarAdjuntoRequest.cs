using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto
{
    public class NewProcesarAdjuntoRequest
    {
        [JsonPropertyName("identificacion")]
        public string Identificacion { get; set; } = string.Empty;

        [JsonPropertyName("categoria")]
        public int Categoria { get; set; }

        [JsonPropertyName("archivoByte")]
        public byte[] ArchivoByte { get; set; }

        [JsonPropertyName("nombreArchivo")]
        public string NombreArchivo { get; set; } = string.Empty;

        [JsonPropertyName("extensionArchivo")]
        public string ExtensionArchivo { get; set; } = string.Empty;

        [JsonPropertyName("idFeature")]
        public string IdFeature { get; set; } = string.Empty;

        [JsonPropertyName("idSolicitud")]
        public string IdSolicitud { get; set; } = string.Empty;

        [JsonPropertyName("idTipoSolicitud")]
        public string IdTipoSolicitud { get; set; } = string.Empty;
    }

}
