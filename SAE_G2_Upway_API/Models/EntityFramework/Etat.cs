using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("etat")]
public partial class Etat
{
    [Key]
    [Column("idetat", TypeName = "integer")]
    public int IdEtat { get; set; }
    
    [Column("nometat")]
    public string NomEtat { get; set; }
    
    //relation avec la table Velo
    public virtual ICollection<Velo> Velos { get; set; } = new List<Velo>();
}