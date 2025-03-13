using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_estcaracterise_estcaract")]
public partial class Est_Caracterise
{
    [Key]
    [Column("estcaract_id")]
    public int IdestCaracterise { get; set; }
    [Column("caract_id")]
    public int IdCaract { get; set; }
    [Column("vel_id")]
    public int IdVelo { get; set; }
    [Column("estcaract_valeurcaracteristique")]
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