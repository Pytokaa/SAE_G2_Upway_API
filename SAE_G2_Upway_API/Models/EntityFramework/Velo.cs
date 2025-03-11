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

        //relation avec la table Rapport inspection
        public RapportInspection? RapportInspection { get; set; }
        
        //relation avec la table taille (min)
        public int IdTailleMin { get; set; }
        [ForeignKey(nameof(IdTailleMin))]
        public Taille TailleMin { get; set; }
        
        //relation avec la table taille (max)
        public int IdTailleMax { get; set; }
        [ForeignKey(nameof(IdTailleMax))]
        public Taille TailleMax { get; set; }
        
        //relation avec la table Modele
        public int IdModele { get; set; }
        [ForeignKey(nameof(IdModele))]
        public Modele Modele { get; set; }
        
        //relationn avec la table etat
        public int IdEtat { get; set; }
        [ForeignKey(nameof(IdEtat))]
        public Etat Etat { get; set; }
        
        
    }