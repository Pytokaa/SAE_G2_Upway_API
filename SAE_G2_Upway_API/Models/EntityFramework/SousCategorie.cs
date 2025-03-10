using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("souscategorie")]
public partial class SousCategorie
{
    [Key]
    [Column("idsouscat")]
    public int IdSousCat { get; set; }
    
    [Column("typesouscat")]
    [StringLength(50)]
    public string TypeSousCat { get; set; }
    
    //relation avec la table caracteristique
    public ICollection<Caracteristique> Caracteristiques { get; set; } = new List<Caracteristique>();
}