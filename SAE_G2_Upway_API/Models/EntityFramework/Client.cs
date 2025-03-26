using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_client_clt")]
public partial class Client
{
    //Colonnes
    [Key]
    [Column("clt_id")]
    public int Idclient { get; set; }
    
    [Column("clt_nom")]
    [StringLength(30)]
    public string Nomclient { get; set; }
    
    [Column("clt_prenom")]
    [StringLength(30)]
    public string Prenomclient { get; set; }
    
    [Column("clt_mail")]
    [StringLength(50)]
    public string Mailclient { get; set; }
    
    [Column("clt_telephone")]
    [StringLength(12)]
    public string Telephone { get; set; }
    
    [Column("clt_password")]
    [StringLength(100)]
    public string Password { get; set; }

    [Column("clt_userrole")]
    [StringLength(100)]
    public string? UserRole { get; set; }
    
    //relation avec la table alerte
    public virtual ICollection<Alerte> Alertes { get; set; } = new List<Alerte>();
    
    //relation avec la table client 
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();


    //Relation avec Est en favoris, un clients peut avoir plusieurs produit en favoris donc une liste
    [InverseProperty(nameof(Est_En_Favoris.ClientFavoris))]
    public virtual ICollection<Est_En_Favoris> LesFavoris { get; set; } = new List<Est_En_Favoris>();
    
    //relation avec la table habite
    [InverseProperty(nameof(Habite.ClientHabite))]
    public virtual ICollection<Habite> HabiteA { get; set; } = new List<Habite>();
}