using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("statut")]
public partial class Statut
{
    //Colonnes
    [Key]
    [Column("idstatut", TypeName = "integer")]
    public int IdStatut { get; set; }
    
    [Column("nomstatut")]
    [StringLength(30)]
    public string NomStatut { get; set; }

    //relation avec la table commande
    [InverseProperty(nameof(Commande.Statut))]
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}