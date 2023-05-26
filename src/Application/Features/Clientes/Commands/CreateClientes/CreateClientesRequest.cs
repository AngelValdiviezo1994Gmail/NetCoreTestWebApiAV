using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Clientes.Commands.CreateClientes
{
    public class CreateClientesRequest
    {
        [JsonPropertyName("id")]
        public int IdCliente { get; set; }

        [JsonPropertyName("nombre")]
        public string NombreCliente { get; set; }

        [JsonPropertyName("apellido")]
        public string ApellidoCliente { get; set; }

        [JsonPropertyName("correo")]
        public string CorreoCliente { get; set; }

        [JsonPropertyName("telefono")]
        public string TelefonoCliente { get; set; }

        [JsonPropertyName("cedula")]
        public string CedulaCliente { get; set; }

        [JsonPropertyName("cursos")]
        public string CursosCliente { get; set; }
    }
}
