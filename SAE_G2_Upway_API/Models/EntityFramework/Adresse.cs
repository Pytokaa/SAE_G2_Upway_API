using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//revoir le fait que dans le mld il y a le id pays et un pays


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table(("adresse"))]
public partial class Adresse
{
    [Key]
    [Column("idadresse")]
    public int IdAdresse { get; set; }
    
    
    [Column("rue")]
    [StringLength(100)]
    public string Rue { get; set; }
    
    [Column("cp")]
    public int Cp { get; set; }
    
    [Column("ville")]
    [StringLength(50)]
    public string Ville { get; set; }
    
   
    //relation avec la table pays
    
    public int PaysId { get; set; }
    
    [ForeignKey(nameof(PaysId))]
    public Pays Pays { get; set; }
    
    //relation avec la table Boutique
    
    public Boutique? Boutique { get; set; }
    
    //relation avec la table commande (adresse simple)
    
    public ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    
    //relation avec la table commande (factu)
    public ICollection<Commande> CommandesFactu { get; set; } = new List<Commande>();
}