using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Domain.Entities.Clientes
{
    [Table("tblClientesNextTi", Schema = "dbo")]
    public class ClientesModels
    {
        [Column("id", Order = 0, TypeName = "int")]
        [Key]
        public int IdCliente { get; set; }

        [Column("nombre", Order = 1, TypeName = "nvarchar")]
        [StringLength(150)]
        public string NombreCliente { get; set; }

        [Column("apellido", Order = 2, TypeName = "nvarchar")]
        [StringLength(150)]
        public string ApellidoCliente { get; set; }

        [Column("correo", Order = 3, TypeName = "nvarchar")]
        [StringLength(250)]
        public string CorreoCliente { get; set; }

        [Column("telefono", Order = 4, TypeName = "nvarchar")]
        [StringLength(10)]
        public string TelefonoCliente { get; set; }

        [Column("cedula", Order = 5, TypeName = "nvarchar")]
        [StringLength(10)]
        public string CedulaCliente { get; set; }

        [Column("cursos", Order = 6, TypeName = "nvarchar")]
        [StringLength(350)]
        public string CursosCliente { get; set; }
    }
}
