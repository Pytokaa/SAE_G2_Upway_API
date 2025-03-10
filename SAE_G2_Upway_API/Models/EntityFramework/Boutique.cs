using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("boutique")]
public partial class Boutique
{
    [Key]
    [Column("idboutique")]
    public int IdBoutique { get; set; }
    
    [Column("nomboutique")]
    [StringLength(50)]
    public string NomBoutique { get; set; }
    
    //relation avec la table Adresse
    
    public int IdAdresse { get; set; }
    
    [ForeignKey(nameof(IdAdresse))]
    public Adresse Adresse { get; set; }
}