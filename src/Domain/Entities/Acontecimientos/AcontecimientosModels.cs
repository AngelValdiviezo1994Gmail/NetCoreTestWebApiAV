using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Domain.Entities.Acontecimientos
{
    [Table("tblAcontecimientoNextTi", Schema = "dbo")]
    public class AcontecimientosModels
    {
        [Column("idAcontecimiento", Order = 0, TypeName = "int")]
        [Key]
        public int idAcontecimiento { get; set; }

        [Column("idEvento", Order = 1, TypeName = "int")]
        public int idEvento { get; set; }

        [Column("nombreEvento", Order = 2, TypeName = "nvarchar")]
        [StringLength(150)]
        public string nombreEvento { get; set; }

        [Column("Fecha", Order = 3, TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [Column("Lugar", Order = 4, TypeName = "nvarchar")]
        [StringLength(150)]
        public string Lugar { get; set; }

        [Column("NumeroEntrada", Order = 5, TypeName = "int")]
        public int NumeroEntrada { get; set; }

        [Column("Descripcion", Order = 6, TypeName = "nvarchar")]
        [StringLength(150)]
        public string Descripcion { get; set; }

        [Column("Precio", Order = 7, TypeName = "int")]
        public int Precio { get; set; }

        [Column("Estado", Order = 8, TypeName = "bit")]
        public bool Estado { get; set; }
    }
}
