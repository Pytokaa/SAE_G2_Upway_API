using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_modepayement_mpay")]
public partial class ModePayement
{
    [Key]
    [Column("mpay_id")]
    public int Idmodepayement { get; set; }
    
    [Column("mpay_nom")]
    [StringLength(50)]
    public string NomModepayement { get; set; }
    
    //relation avec la table Commande
    
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    
}