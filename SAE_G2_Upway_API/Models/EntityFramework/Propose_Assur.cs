using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_j_proposeassur_propassur")]
public partial class Propose_Assur
{
    [Key]
    [Column("propassur_id")]
    public int IdProposeAssur { get; set; }
    [Column("assur_id")]
    public int IdAssurance { get; set; }
    [Column("comm_id")]
    public int IdCommande { get; set; }

    //relation avec la table commande
    [ForeignKey(nameof(IdCommande))]
    [InverseProperty(nameof(Commande.AssurancesPropose))]
    public virtual Commande Commande { get; set; } = null!;
    
    //relation avec la table assurance
    [ForeignKey(nameof(IdAssurance))]
    [InverseProperty(nameof(Assurance.AssureCommande))]
    public virtual Assurance Assurance { get; set; } = null !;
}