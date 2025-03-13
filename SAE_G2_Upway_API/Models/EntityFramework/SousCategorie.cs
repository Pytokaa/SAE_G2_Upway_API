using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_souscategorie_scat")]
public partial class SousCategorie
{
    [Key]
    [Column("scat_id")]
    public int IdSousCat { get; set; }
    
    [Column("scat_type")]
    [StringLength(50)]
    public string TypeSousCat { get; set; }
    
    //relation avec la table caracteristique
    public ICollection<Caracteristique> Caracteristiques { get; set; } = new List<Caracteristique>();

    //relation avec possede/velo
    [InverseProperty(nameof(Possede.LaSousCategorie))]
    public virtual ICollection<Possede> LesVelos { get; set; } = new List<Possede>();
}