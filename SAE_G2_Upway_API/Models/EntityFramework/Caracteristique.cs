using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_caracteristique_caract")]
public partial class Caracteristique
{
    [Key]
    [Column("caract_id")]
    public int IdCaract { get; set; }
    [Column("scat_id")]
    public int IdSousCat  { get; set; }
    
    
    [Column("caract_type")]
    [StringLength(100)]
    public string Typecaract { get; set; }
    
    
    
    //relation avec la table souscategorie
    [ForeignKey(nameof(IdSousCat))]
    public virtual SousCategorie SousCategorie { get; set; } = null!;
    
    //relation avec la table est_caracterise oui
    [InverseProperty(nameof(Est_Caracterise.Caracterise))]
    public virtual ICollection<Est_Caracterise> CaracteriseVelo { get; set; } =  new List<Est_Caracterise>();
    
}