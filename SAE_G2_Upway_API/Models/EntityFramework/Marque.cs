using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_marque_mrq")]
public partial class Marque
{
    [Key]
    [Column("mrq_id")]
    public int IdMarque { get; set; }
    
    [Column("mrq_nom")]
    [StringLength(30)]
    public string NomMarque { get; set; }
    
    //relation avec la table modele
    public virtual ICollection<Modele> Modeles { get; set; } = new List<Modele>();

    //relation avec la table Produit
    [InverseProperty(nameof(Produit.Marque))]
    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
}