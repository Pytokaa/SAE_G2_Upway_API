using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("assurance")]
public partial class Assurance
{
    [Key]
    [Column("idassurance")]
    public int IdAssurance { get; set; }
    
    [Column("nomassurance")]
    [StringLength(50)]
    public string NomAssurance { get; set; }
    
    [Column("prixassurance",TypeName = "decimal(5,2)")]
    public decimal PrixAssurance { get; set; }
    
    //relation avec la table propose_assur
    [InverseProperty(nameof(Propose_Assur.Assurance))]
    public virtual ICollection<Propose_Assur> AssureCommande { get; set; } =  new List<Propose_Assur>();
}