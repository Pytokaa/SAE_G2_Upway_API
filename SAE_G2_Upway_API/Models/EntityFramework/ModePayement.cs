using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("modepayement")]
public partial class ModePayement
{
    [Key]
    [Column("idmodepayement")]
    public int Idmodepayement { get; set; }
    
    [Column("nommodepayement")]
    [StringLength(50)]
    public string NomModepayement { get; set; }
    
    //relation avec la table Commande
    
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    
}