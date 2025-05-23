using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_modele_mdl")]
public partial class Modele
{
    [Key]
    [Column("mdl_id")]
    public int IdModele { get; set; }
    [Column("mrq_id")]
    public int IdMarque { get; set; }
    
    [Column("mdl_nom")]
    [StringLength(200)]
    public string NomModele { get; set; }
    
    // relation avec la table marque
    [ForeignKey(nameof(IdMarque))]
    public Marque Marque { get; set; } = null!;
    
    
    //relation avecc la table Velo
    public virtual ICollection<Velo> Velos { get; set; } = new List<Velo>();

    //relation avec la table moteur
    [InverseProperty(nameof(Est_De_ModeleM.LeModele))]
    public virtual ICollection<Est_De_ModeleM> LesMoteurs { get; set; } = new List<Est_De_ModeleM>();
}