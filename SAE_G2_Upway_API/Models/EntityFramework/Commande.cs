using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("commande")]
public partial class Commande
{
    [Key]
    [Column("idcommande")]
    public int IdCommande { get; set; }
    
    [Column("datecommande")]
    public DateTime DateCommande { get; set; }
    
    [Column("idcode")]
    public int? IdCode { get; set; }
    
    [Column("idstatut")]
    public int IdStatut { get; set; }
    
    [Column("idmodeexp")]
    public int IdModeExp { get; set; }
    
    [Column("idadresse")]
    public int IdAdresse { get; set; }
    [Column("idboutique")]
    public int? IdBoutique { get; set; }
    [Column("idadressefactu")]
    public int? IdAdresseFactu { get; set; }
    [Column("idmodepayement")]
    public int IdModePayement { get; set; }
    
    [Column("idclient")]
    public int IdClient { get; set; }
    
    //relation avec la table codereduc
    [ForeignKey(nameof(IdCode))]
    public virtual CodeReduc? Code { get; set; }
    
    //relation avec la table statut
    [ForeignKey(nameof(IdStatut))]
    public virtual Statut Statut { get; set; } = null!;
    
    //relation avec la table modeExpedition
    
    [ForeignKey(nameof(IdModeExp))]
    public virtual ModeExpedition? ModeExpedition { get; set; }
    
    //relation avec la table adresse (adresse simple)
    [ForeignKey(nameof(IdAdresse))]
    public virtual Adresse Adresse { get; set; } = null!;
    
    //relation avec la table boutique
    
    [ForeignKey(nameof(IdBoutique))]
    public virtual Boutique? Boutique { get; set; }
    
    //relation avec la table adresse (facturation)
    [ForeignKey(nameof(IdAdresseFactu))]
    public virtual Adresse? AdresseFactu { get; set; };
    
    //relation avec la table ModePayement
    
    [ForeignKey(nameof(IdModePayement))]
    public virtual ModePayement ModePayement { get; set; } = null!;
    
    //relation avec la table Client
    [ForeignKey(nameof(IdClient))]
    public virtual Client Client { get; set; } = null!;
    
    //relation avec la table propose_assur
    [InverseProperty(nameof(Propose_Assur.Commande))]
    public virtual ICollection<Propose_Assur> AssurancesPropose { get; set; } =  new List<Propose_Assur>();

    //relation avec la table est_propose_similaire qui fait la fonction avec commande
    [InverseProperty(nameof(Est_Propose_Similaire.LaCommande))]
    public virtual ICollection<Est_Propose_Similaire> LesSimilaires { get; set; } = new List<Est_Propose_Similaire>();

    //relation avec la table est_mis_panier_accessoire qui fait la jonction avec accessoire
    [InverseProperty(nameof(Est_Mis_Panier_Accessoire.LaCommande))]
    public virtual ICollection<Est_Mis_Panier_Accessoire> LesAccessoires { get; set; } = new List<Est_Mis_Panier_Accessoire>();
    
    //relatino avec la table est_mis_panier_velo
    
    [InverseProperty(nameof(Est_Mis_Panier_Velo.PanierCommande))]
    public virtual ICollection<Est_Mis_Panier_Velo> PanierVelo { get; set; } = new List<Est_Mis_Panier_Velo>();
    
}