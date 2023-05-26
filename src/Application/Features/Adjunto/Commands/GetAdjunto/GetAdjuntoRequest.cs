using System.Text.Json.Serialization;

namespace WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto
{
    public class GetAdjuntoRequest
    {
        [JsonPropertyName("identificacion")]
        public string Identificacion { get; set; } = string.Empty;

        [JsonPropertyName("idFeature")]
        public string IdFeature { get; set; } = string.Empty;

    }
}

