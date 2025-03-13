using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_etat_eta")]
public partial class Etat
{
    [Key]
    [Column("eta_id")]
    public int IdEtat { get; set; }
    
    [Column("eta_nom")]
    public string NomEtat { get; set; }
    
    //relation avec la table Velo
    public virtual ICollection<Velo> Velos { get; set; } = new List<Velo>();
}