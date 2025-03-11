using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


// il faut ajouter encore les liens vers les autres tables lorsqu'elle seront créées
namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("rapportinspection")]
public partial class RapportInspection
{
    [Key]
    [Column("idrapport")] 
    public int IdRapport { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }
    
    [Column("centre")]
    [StringLength(100)]
    public string Centre { get; set; }
    
    
    [Column("historique")]
    [StringLength(500)]
    public string Historique { get; set; }
    
    [Column("commentaire")]
    [StringLength(500)]
    public string Commentaire { get; set; }
    
    //relation avec la table Produit
    public int IdProduit { get; set; }
    [ForeignKey(nameof(Produit))]
    public Produit Produit { get; set; }
    
    //relation avec la table Velo
    public int IdVelo { get; set; }
    [ForeignKey(nameof(IdVelo))]
    public Velo Velo { get; set; }
}