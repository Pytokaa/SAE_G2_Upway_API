using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


// il faut ajouter encore les liens vers les autres tables lorsqu'elle seront créées
namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_rapportinspection_rapinsp")]
public partial class RapportInspection
{
    [Key]
    [Column("rapinsp_id")] 
    public int IdRapport { get; set; }

    [Column("vel_id")]
    public int IdVelo { get; set; }

    [Column("rapinsp_date")]
    public DateTime Date { get; set; }
    
    [Column("rapinsp_centre")]
    [StringLength(250)]
    public string Centre { get; set; }
    
    
    [Column("rapinsp_historique")]
    [StringLength(500)]
    public string Historique { get; set; }
    
    [Column("rapinsp_commentaire")]
    [StringLength(500)]
    public string Commentaire { get; set; }

    //relation avec la table Velo

    [ForeignKey(nameof(IdVelo))]
    [InverseProperty(nameof(Velo.RapportInspection))]
    public Velo LeVelo { get; set; } = null!;


    //relation avec la table valide
    [InverseProperty(nameof(Valide.LeRapport))]
    public virtual ICollection<Valide> LesTypes { get; set; } = new List<Valide>();
}