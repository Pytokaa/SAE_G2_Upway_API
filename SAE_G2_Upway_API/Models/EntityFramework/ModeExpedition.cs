using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("modeexpedition")]
public partial class ModeExpedition
{
    [Key]
    [Column("idmodeexp", TypeName = "integer")]
    public int IdModeExp { get; set; }
    
    [Column("libellemodeexp")]
    [StringLength(30)]
    public string LibellemodeExp { get; set; }  
    
    //relation avec la table commande
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}