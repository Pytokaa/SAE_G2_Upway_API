using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("statut")]
public partial class Statut
{
    [Key]
    [Column("idstatut")]
    public int IdStatut { get; set; }
    
    [Column("nomstatut")]
    [StringLength(30)]
    public string NomStatut { get; set; }
    
    //relation avec la table commande
    public ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}