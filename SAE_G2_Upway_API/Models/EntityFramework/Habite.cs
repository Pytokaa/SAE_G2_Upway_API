using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_j_habite_hab")]
public partial class Habite
{
    [Key]
    [Column("hab_id")]
    public int Idhabite { get; set; }
    [Column("clt_id")]
    public int? Idclient { get; set; }
    [Column("adr_id")]
    public int Idadresse { get; set; }
    
    //relation avec la table client
    [ForeignKey(nameof(Idclient))]
    [InverseProperty(nameof(Client.HabiteA))]
    public virtual Client? ClientHabite { get; set; }
    
    //relation avec la table adresse
    [ForeignKey(nameof(Idadresse))]
    [InverseProperty(nameof(Adresse.AClients))]
    public virtual Adresse AdresseHabite { get; set; } = null!;
    
    
}