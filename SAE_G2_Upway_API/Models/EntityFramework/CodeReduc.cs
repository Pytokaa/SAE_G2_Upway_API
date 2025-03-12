using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("codereduc")]
public partial class CodeReduc
{
    [Key]
    [Column("idcode")]
    public int Idcode { get; set; }
    
    [Column("libellecode")]
    [StringLength(30)]
    public string Libellecode { get; set; }
    
    //relation avec la table commande
    public ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}