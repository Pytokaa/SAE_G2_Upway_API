using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_statut_stu")]
public partial class Statut
{
    //Colonnes
    [Key]
    [Column("stu_id")]
    public int IdStatut { get; set; }
    
    [Column("stu_nom")]
    [StringLength(30)]
    public string NomStatut { get; set; }

    //relation avec la table commande
    [InverseProperty(nameof(Commande.Statut))]
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}