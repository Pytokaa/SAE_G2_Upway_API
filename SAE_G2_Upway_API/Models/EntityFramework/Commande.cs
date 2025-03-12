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
    
    //relation avec la table codereduc
    public int IdCode { get; set; }
    [ForeignKey(nameof(IdCode))]
    public CodeReduc Code { get; set; }
    
    //relation avec la table statut
    public int IdStatut { get; set; }
    [ForeignKey(nameof(IdStatut))]
    public Statut Statut { get; set; }
    
    //relation avec la table modeExpedition
    public int IdModeExp { get; set; }
    [ForeignKey(nameof(IdModeExp))]
    public ModeExpedition ModeExpedition { get; set; }
    
    //relation avec la table adresse (adresse simple)
    
    public int IdAdresse { get; set; }
    [ForeignKey(nameof(IdAdresse))]
    public Adresse Adresse { get; set; }
    
    //relation avec la table boutique
    public int IdBoutique { get; set; }
    [ForeignKey(nameof(IdBoutique))]
    public Boutique Boutique { get; set; }
    
    //relation avec la table adresse (facturation)
    public int IdAdresseFactu { get; set; }
    [ForeignKey(nameof(IdAdresseFactu))]
    public Adresse AdresseFactu { get; set; }
    
    //relation avec la table ModePayement
    public int IdModePayement { get; set; }
    [ForeignKey(nameof(IdModePayement))]
    public ModePayement ModePayement { get; set; }
    
    //relation avec la table Client
    public int IdClient { get; set; }
    [ForeignKey(nameof(IdClient))]
    public Client Client { get; set; }
    
    //relation avec la table propose_assur
    [InverseProperty(nameof(Propose_Assur.Commande))]
    public virtual ICollection<Propose_Assur> AssurancesPropose { get; set; } =  new List<Propose_Assur>();

    [InverseProperty(nameof(Est_Propose_Similaire.LaCommande))]
    public virtual ICollection<Est_Propose_Similaire> LesSimilaires { get; set; } = new List<Est_Propose_Similaire>();

    [InverseProperty(nameof(Est_Mis_Panier_Accessoire.LaCommande))]
    public virtual ICollection<Est_Mis_Panier_Accessoire> LesAccessoires { get; set; } = new List<Est_Mis_Panier_Accessoire>();
}