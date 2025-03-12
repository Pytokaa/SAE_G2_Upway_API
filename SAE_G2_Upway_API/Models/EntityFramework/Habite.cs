using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("habite")]
public partial class Habite
{
    [Key]
    [Column("idhabite", TypeName = "integer")]
    public int Idhabite { get; set; }
    [Column("idclient")]
    public int Idclient { get; set; }
    [Column("idadresse")]
    public int Idadresse { get; set; }
    
    //relation avec la table client
    [ForeignKey(nameof(Idclient))]
    [InverseProperty(nameof(Client.HabiteA))]
    public virtual Client ClientHabite { get; set; } = null!;
    
    //relation avec la table adresse
    [ForeignKey(nameof(Idadresse))]
    [InverseProperty(nameof(Adresse.AClients))]
    public virtual Adresse AdresseHabite { get; set; } = null!;
    
    
}