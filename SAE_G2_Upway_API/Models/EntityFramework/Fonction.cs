using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_fonction_fn")]
public partial class Fonction
{
    [Key]
    [Column("fn_id")]
    public int Id { get; set; }
    
    [Column("fn_nom")]
    [StringLength(80)]
    public string NomFonction { get; set; }
    
    //relation avec la table client
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    
}