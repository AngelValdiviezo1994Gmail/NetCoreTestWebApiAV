using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiTest.Domain.Entities;

[Table("AD_Adjuntos", Schema = "dbo")]
public class Adjuntos
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

    [NotMapped]
    public string ArchivoBase64 { get; set; } = string.Empty;

    [NotMapped]
    public byte[] ArchivoByte { get; set; }

    [Column("nombreArchivo", Order = 5, TypeName = "varchar")]
    public string NombreArchivo { get; set; } = string.Empty;

    [NotMapped]
    public string ExtensionArchivo { get; set; } = string.Empty;

    [Column("rutaAcceso", Order = 6, TypeName = "varchar")]
    public string RutaAcceso { get; set; } = string.Empty;

    [Column("estado", Order = 7, TypeName = "varchar")]
    public string Estado { get; set; } = string.Empty;

    //AUDITORIA
    [Column("usuarioCreacion", Order = 8, TypeName = "varchar")]
    public string UsuarioCreacion { get; set; } = string.Empty;

    [Column("fechaCreacion", Order = 9, TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; } = System.DateTime.Now;

    [Column("usuarioModificacion", Order = 10, TypeName = "varchar")]
    public string UsuarioModificacion { get; set; } = string.Empty;

    [Column("fechaModificacion", Order = 11, TypeName = "datetime")]
    public Nullable<System.DateTime> FechaModificacion { get; set; }

}

