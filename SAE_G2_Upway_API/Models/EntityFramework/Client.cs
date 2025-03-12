using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("client")]
public partial class Client
{
    //Colonnes
    [Key]
    [Column("idclient")]
    public int Idclient { get; set; }
    
    [Column("nomclient")]
    [StringLength(30)]
    public string Nomclient { get; set; }
    
    [Column("prenomclient")]
    [StringLength(30)]
    public string Prenomclient { get; set; }
    
    [Column("mailclient")]
    [StringLength(50)]
    public string Mailclient { get; set; }
    
    [Column("telephone")]
    [StringLength(12)]
    public string Telephone { get; set; }
    
    [Column("password")]
    [StringLength(100)]
    public string Password { get; set; }
    
    
    //relation avec la table fonction
    
    public int IdFonction { get; set; }
    [ForeignKey(nameof(IdFonction))]
    public virtual Fonction Fonction { get; set; }
    
    //relation avec la table alerte
    public virtual ICollection<Alerte> Alertes { get; set; } = new List<Alerte>();
    
    //relation avec la table client 
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();


    //Relation avec Est en favoris, un clients peut avoir plusieurs produit en favoris donc une liste
    [InverseProperty(nameof(Est_En_Favoris.ClientFavoris))]
    public virtual ICollection<Est_En_Favoris> LesFavoris { get; set; } = new List<Est_En_Favoris>();
}