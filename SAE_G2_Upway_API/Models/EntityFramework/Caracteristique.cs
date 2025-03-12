using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("caracteristique")]
public partial class Caracteristique
{
    [Key]
    [Column("idcaract")]
    public int IdCaract { get; set; }
    
    
    [Column("typecaract")]
    [StringLength(100)]
    public string Typecaract { get; set; }
    
    //relation avec la table souscategorie
    
    public int IdSousCat  { get; set; }
    
    [ForeignKey(nameof(IdSousCat))]
    public SousCategorie SousCategorie { get; set; }
    
    //relation avec la table est_caracterise
    [InverseProperty(nameof(Est_Caracterise.Caracterise))]
    public virtual ICollection<Est_Caracterise> CaracteriseVelo { get; set; } =  new List<Est_Caracterise>();
    
}