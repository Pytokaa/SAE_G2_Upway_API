using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("propose_assur")]
public partial class Propose_Assur
{
    [Key]
    [Column("idproposeassur")]
    public int IdProposeAssur { get; set; }
    [Column("idassurance")]
    public int IdAssurance { get; set; }
    [Column("idcommande")]
    public int IdCommande { get; set; }
    
    //relation avec la table commande
    [ForeignKey(nameof(IdCommande))]
    [InverseProperty(nameof(Commande.AssurancesPropose))]
    public virtual Commande Commande { get; set; }
    
    //relation avec la table assurance
    [ForeignKey(nameof(IdAssurance))]
    [InverseProperty(nameof(Assurance.AssureCommande))]
    public virtual Assurance Assurance { get; set; }
}