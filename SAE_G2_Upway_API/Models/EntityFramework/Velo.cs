using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


// il faut ajouter encore les liens vers les autres tables lorsqu'elle seront créées
namespace SAE_G2_Upway_API.Models.EntityFramework;


    [Table("velo")]
    public partial class Velo
    {
        [Key]
        [Column("idvelo")]
        public int Idvelo { get; set; }
        
        [Column("nbkms")]
        public double Nbkms { get; set; }
        
        [Column("prixneuf")]
        public double Prixneuf { get; set; }
        
        [Column("poids")]
        public double Poids { get; set; }
        
        [Column("typecadre")]
        [StringLength(50)]
        public string Typecadre { get; set; }
        
        
        
        
        
        
        
    }