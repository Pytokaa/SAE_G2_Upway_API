using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_boutique_btq")]
public partial class Boutique
{
    [Key]
    [Column("btq_id")]
    public int IdBoutique { get; set; }
    
    [Column("btq_nom")]
    [StringLength(50)]
    public string NomBoutique { get; set; }
    
    [Column("adr_id")]
    public int IdAdresse { get; set; }
    
    
    //relation avec la table Adresse
    
    [ForeignKey(nameof(IdAdresse))]
    public virtual Adresse Adresse { get; set; } = null!;
    
    //relation avec la table commande
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    //relation avec peut etre teste

    [InverseProperty(nameof(Peut_Etre_Teste.LaBoutique))]
    public virtual ICollection<Peut_Etre_Teste> LesVelos { get; set; } = new List<Peut_Etre_Teste>();

}