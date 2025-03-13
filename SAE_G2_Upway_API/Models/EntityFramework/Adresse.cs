using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//revoir le fait que dans le mld il y a le id pays et un pays


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table(("t_e_adresse_adr"))]
public partial class Adresse
{
    [Key]
    [Column("adr_id")]
    public int IdAdresse { get; set; }
    
    [Column("pays_id")]
    public int PaysId { get; set; }
    
    [Column("adr_rue")]
    [StringLength(250)]
    public string Rue { get; set; }
    
    [Column("adr_cp")]
    public int Cp { get; set; }
    
    [Column("adr_ville")]
    [StringLength(50)]
    public string Ville { get; set; }
    
   
    //relation avec la table pays
    [ForeignKey(nameof(PaysId))]
    public virtual Pays Pays { get; set; } = null!;
    
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