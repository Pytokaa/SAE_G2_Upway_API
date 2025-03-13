using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_assurance_assur")]
public partial class Assurance
{
    [Key]
    [Column("assur_id")]
    public int IdAssurance { get; set; }
    
    [Column("assur_nom")]
    [StringLength(50)]
    public string NomAssurance { get; set; }
    
    [Column("assur_prix",TypeName = "decimal(5,2)")]
    public decimal PrixAssurance { get; set; }
    
    //relation avec la table propose_assur
    [InverseProperty(nameof(Propose_Assur.Assurance))]
    public virtual ICollection<Propose_Assur> AssureCommande { get; set; } =  new List<Propose_Assur>();
}