using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Domain.Entities.Eventos
{

    [Table("tblEventoNextTi", Schema = "dbo")]
    public class tblEventoNextTi
    {
        [Column("idEvento", Order = 0, TypeName = "int")]
        [Key]
        public int idEvento { get; set; }

        [Column("nombreEvento", Order = 1, TypeName = "nvarchar")]
        [StringLength(150)]
        public string nombreEvento { get; set; }
    }
}
