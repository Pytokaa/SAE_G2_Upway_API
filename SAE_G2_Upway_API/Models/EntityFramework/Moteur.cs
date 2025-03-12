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

    [Column("vitessemax")] public int VitesseMax { get; set; }

    [InverseProperty(nameof(Est_Compose.LeMoteur))]
    public virtual ICollection<Est_Compose> LesVelos { get; set; } = new List<Est_Compose>();
}