using System.Text.Json.Serialization;

namespace WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto
{
    public class ProcesarAdjuntoRequest
    {
        [JsonPropertyName("identificacion")]
        public string Identificacion { get; set; } = string.Empty;

        [JsonPropertyName("categoria")]
        public int Categoria { get; set; }

        [JsonPropertyName("archivoBase64")]
        public string ArchivoBase64 { get; set; } = string.Empty;

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
