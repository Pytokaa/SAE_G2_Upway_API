using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("boutique")]
public partial class Boutique
{
    [Key]
    [Column("idboutique")]
    public int IdBoutique { get; set; }
    
    [Column("nomboutique")]
    [StringLength(50)]
    public string NomBoutique { get; set; }
    
    [Column("idadresse")]
    public int IdAdresse { get; set; }
    
    
    //relation avec la table Adresse
    
    [ForeignKey(nameof(IdAdresse))]
    public virtual Adresse? Adresse { get; set; }
    
    //relation avec la table commande
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    //relation avec peut etre teste

    [InverseProperty(nameof(Peut_Etre_Teste.LaBoutique))]
    public virtual ICollection<Peut_Etre_Teste> LesVelos { get; set; } = new List<Peut_Etre_Teste>();

}