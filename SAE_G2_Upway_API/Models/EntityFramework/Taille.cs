using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("taille")]
public partial class Taille
{
    [Key]
    [Column("idtaille", TypeName = "integer")]
    public int Idtaille { get; set; }
    
    [Column("taillecm")]
    public int TailleCm { get; set; }
    
    //relation avec la table Alerte
    public ICollection<Alerte> Alerte { get; set; } =  new List<Alerte>();
    
    //relation avec la table velo (min)
    public ICollection<Velo> VelosMin { get; set; } =  new List<Velo>();
    
    //relation avec la table velo (max)
    public ICollection<Velo> VelosMax { get; set; } =  new List<Velo>();
}