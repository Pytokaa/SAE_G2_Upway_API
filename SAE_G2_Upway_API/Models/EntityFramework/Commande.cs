using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("commande")]
public partial class Commande
{
    [Key]
    [Column("idcommande")]
    public int IdCommande { get; set; }
    
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
    
    //relation avec la table adresse (facturation)
    public int IdAdresseFactu { get; set; }
    [ForeignKey(nameof(IdAdresseFactu))]
    public Adresse AdresseFactu { get; set; }
    
    //relation avec la table ModePayement
    public int IdModePayement { get; set; }
    [ForeignKey(nameof(IdModePayement))]
    public ModePayement ModePayement { get; set; }
    
    
}