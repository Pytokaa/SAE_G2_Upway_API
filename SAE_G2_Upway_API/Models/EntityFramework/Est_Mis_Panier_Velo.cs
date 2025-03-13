using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Connections.Features;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_j_estmispaniervelo_empanvel")]
public partial class Est_Mis_Panier_Velo
{
    [Key]
    [Column("empanvel_id")]
    public int IdPanierVelo { get; set; }
    [Column("vel_id")]
    public int IdVelo { get; set; }
    [Column("comm_id")]
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