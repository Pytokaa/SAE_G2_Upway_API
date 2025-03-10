using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("alerte")]
public partial class Alerte
{
    [Key]
    [Column("idalerte")]
    public int IdAlerte { get; set; }
    
    [Column("budgetmax")]
    public int Budgetmax { get; set; }
    
    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; }
    
    
    //relation avec la table client
    
    public int Idclient { get; set; }
    
    [ForeignKey(nameof(Idclient))]
    public Client Client { get; set; }
    
    //relation avec la table taille
    
    public int IdTaille { get; set; }
    
    [ForeignKey(nameof(IdTaille))]
    public Taille Taille { get; set; }
}