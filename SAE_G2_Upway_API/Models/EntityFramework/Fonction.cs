using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("fonction")]
public partial class Fonction
{
    [Key]
    [Column("idfonction")]
    public int Id { get; set; }
    
    [Column("nomfonction")]
    [StringLength(80)]
    public string NomFonction { get; set; }
    
    //relation avec la table client
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    
}