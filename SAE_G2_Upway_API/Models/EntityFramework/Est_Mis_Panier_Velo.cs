using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Connections.Features;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("est_mis_panier_velo")]
public partial class Est_Mis_Panier_Velo
{
    [Key]
    [Column("idpaniervelo")]
    public int IdPanierVelo { get; set; }
    [Column("idvelo")]
    public int IdVelo { get; set; }
    [Column("idcommande")]
    public int IdCommande { get; set; }
    
    //relation avec la table velo
    [ForeignKey(nameof(IdVelo))]
    [InverseProperty(nameof(Velo.ACommandes))]
    public virtual Velo PanierVelo { get; set; } = null!;
        
    //relation avec la table commande
    [ForeignKey(nameof(IdCommande))]
    [InverseProperty(nameof(Commande.PanierVelo))]
    public virtual Commande PanierCommande { get; set; } = null!;
}