using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Domain.Entities.Eventos
{
    [Table("tblEventoNextTi", Schema = "dbo")]
    public class EventosModels
    {
        [Column("idEvento", Order = 0, TypeName = "int")]
        public int idEvento { get; set; }

        [Column("nombreEvento", Order = 1, TypeName = "nvarchar")]
        [StringLength(150)]
        public string nombreEvento { get; set; }
    }
}
