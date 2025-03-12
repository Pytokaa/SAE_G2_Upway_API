using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("alerte")]
public partial class Alerte
{
    [Key]
    [Column("idalerte")]
    public int IdAlerte { get; set; }
    
    [Column("idclient")]
    public int IdClient { get; set; }
    
    [Column("idtaille")]
    public int IdTaille { get; set; }
    
    [Column("budgetmax")]
    public int Budgetmax { get; set; }
    
    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; }
    
    
    //relation avec la table client
    [ForeignKey(nameof(IdClient))]
    public virtual Client? Client { get; set; }
    
    
    //relation avec la table taille
    [ForeignKey(nameof(IdTaille))]
    public virtual Taille Taille { get; set; } = null!;
    
    
    
    //relation avec la table Concerne
    [InverseProperty(nameof(Concerne.ConcerneAlerte))]
    public virtual ICollection<Concerne> EstConcerneCategorie { get; set; } =  new List<Concerne>();
}