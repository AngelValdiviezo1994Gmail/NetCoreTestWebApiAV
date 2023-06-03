using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Domain.Entities
{

    [Table("AD_Adjuntos", Schema = "dbo")]
    public class Features
    {
        [Key]
        [Column("id", Order = 0, TypeName = "uniqueidentifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("identificacion", Order = 1, TypeName = "varchar")]
        public string Identificacion { get; set; } = string.Empty;

        [NotMapped]
        public int Categoria { get; set; }

        [Column("idFeature", Order = 2, TypeName = "varchar")]
        public string IdFeature { get; set; } = string.Empty;

        [Column("idSolicitud", Order = 3, TypeName = "varchar")]
        public string IdSolicitud { get; set; } = string.Empty;

        [Column("idTipoSolicitud", Order = 4, TypeName = "varchar")]
        public string IdTipoSolicitud { get; set; } = string.Empty;

        public virtual ICollection<Adjuntos> archivosAdjuntos { get; set; } 

    }

}
