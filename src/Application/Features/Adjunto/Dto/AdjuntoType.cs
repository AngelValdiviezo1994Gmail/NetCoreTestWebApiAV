using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Adjunto.Dto
{
    public class AdjuntoType
    {
        public Guid Id { get; set; }
        public string RutaAcceso { get; set; } = string.Empty;

        public string NombreArchivo { get; set; } = string.Empty;
    }
}
