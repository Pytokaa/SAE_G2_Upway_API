using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_codereduc_codred")]
public partial class CodeReduc
{
    [Key]
    [Column("codred_id")]
    public int Idcode { get; set; }
    
    [Column("codred_libelle")]
    [StringLength(30)]
    public string Libellecode { get; set; }
    
    //relation avec la table commande
    public ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}