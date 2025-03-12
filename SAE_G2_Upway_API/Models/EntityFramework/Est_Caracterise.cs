using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("est_caracterise")]
public partial class Est_Caracterise
{
    [Key]
    [Column("idestcaracterise")]
    public int IdestCaracterise { get; set; }
    [Column("idcaract")]
    public int IdCaract { get; set; }
    [Column("idvelo")]
    public int IdVelo { get; set; }
    [Column("valeurcaracteristique")]
    [StringLength(200)]
    public string ValeurCaracteristique { get; set; }
    
    //relation avec la table velo
    [ForeignKey(nameof(IdVelo))]
    [InverseProperty(nameof(Velo.Caracteristiques))]
    public virtual Velo CaracteriseVelo { get; set; } = null!;
    
    //relation avec la table caracteristique oui
    [ForeignKey(nameof(IdCaract))]
    [InverseProperty(nameof(Caracteristique.CaracteriseVelo))]
    public virtual Caracteristique Caracterise { get; set; } = null!;
}