using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_modeexpedition_modexpe")]
public partial class ModeExpedition
{
    [Key]
    [Column("modexpe_id")]
    public int IdModeExp { get; set; }
    
    [Column("modexpe_libelle")]
    [StringLength(30)]
    public string LibellemodeExp { get; set; }  
    
    //relation avec la table commande
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}