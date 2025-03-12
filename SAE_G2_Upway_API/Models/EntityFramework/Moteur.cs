using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("moteur")]
public partial class Moteur
{
    [Key]
    [Column("idmoteur")]
    public int IdMoteur { get; set; }
    
    [Column("positionmoteur")]
    [StringLength(20)]
    public int Positionmoteur { get; set; }
    
    [Column("couplemoteur")]
    public int CoupleMoteur { get; set; }

    [Column("vitessemax")] 
    public int VitesseMax { get; set; }
    
    //relation avec la table est_compose
    [InverseProperty(nameof(Est_Compose.LeMoteur))]
    public virtual ICollection<Est_Compose> LesVelos { get; set; } = new List<Est_Compose>();

    //relation avec la table est_de_modelem
    [InverseProperty(nameof(Est_De_ModeleM.LeMoteur))]
    public virtual ICollection<Est_De_ModeleM> LesModeles { get; set; } = new List<Est_De_ModeleM>();
}