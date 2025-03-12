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
    
    [Column("idpays")]
    public int PaysId { get; set; }
    
    [Column("rue")]
    [StringLength(100)]
    public string Rue { get; set; }
    
    [Column("cp")]
    public int Cp { get; set; }
    
    [Column("ville")]
    [StringLength(50)]
    public string Ville { get; set; }
    
   
    //relation avec la table pays
    [ForeignKey(nameof(PaysId))]
    public virtual Pays Pays { get; set; }
    
    //relation avec la table Boutique
    public virtual Boutique? Boutique { get; set; }
    
    //relation avec la table commande (adresse simple)
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    
    //relation avec la table commande (factu)
    public virtual ICollection<Commande> CommandesFactu { get; set; } = new List<Commande>();
    
    
    //relation avec la table habite
    [InverseProperty(nameof(Habite.AdresseHabite))]
    public virtual ICollection<Habite> AClients { get; set; } = new List<Habite>();
}