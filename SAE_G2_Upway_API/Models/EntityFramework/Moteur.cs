using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_moteur_mtr")]
public partial class Moteur
{
    [Key]
    [Column("mtr_id")]
    public int IdMoteur { get; set; }
    
    [Column("mtr_position")]
    [StringLength(20)]
    public string Positionmoteur { get; set; }
    
    [Column("mtr_couple")]
    public int CoupleMoteur { get; set; }

    [Column("mtr_vitessemax")] 
    public int VitesseMax { get; set; }
    
    //relation avec la table est_compose
    [InverseProperty(nameof(Est_Compose.LeMoteur))]
    public virtual ICollection<Est_Compose> LesVelos { get; set; } = new List<Est_Compose>();

    //relation avec la table est_de_modelem
    [InverseProperty(nameof(Est_De_ModeleM.LeMoteur))]
    public virtual ICollection<Est_De_ModeleM> LesModeles { get; set; } = new List<Est_De_ModeleM>();
}