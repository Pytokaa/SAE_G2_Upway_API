using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("type")]
public partial class Type
{
    //Colonne
    [Key]
    [Column("idtype", TypeName = "integer")]
    public int Idtype { get; set; }
    
    [Column("nomtype")]
    [StringLength(50)]
    public string NomType { get; set; }
    
    //Relation avec La table valide
    [InverseProperty(nameof(Valide.LeType))]
    public virtual ICollection<Valide> LesRapports { get; set; } = new List<Valide>();
    
    //relation avec la table contient
    [InverseProperty(nameof(Contient.ContientType))]
    public virtual ICollection<Contient> ASousTypes { get; set; } = new List<Contient>();
}