using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("etat")]
public partial class Etat
{
    [Key]
    [Column("idetat")]
    public int IdEtat { get; set; }
    
    [Column("nometat")]
    public string NomEtat { get; set; }
}