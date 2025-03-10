using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("taille")]
public partial class Taille
{
    [Key]
    [Column("idtaille")]
    public int Idtaille { get; set; }
    
    [Column("taillecm")]
    public int TailleCm { get; set; }
    
    //relation avec la table Alerte
    public ICollection<Alerte> Alerte { get; set; } =  new List<Alerte>();
}