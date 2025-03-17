using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


// il faut ajouter encore les liens vers les autres tables lorsqu'elle seront créées
namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_velo_vel")]
public partial class Velo
{
    [Key]
    [Column("vel_id")]
    public int IdVelo { get; set; }

    [Column("pdt_id")]
    public int IdProduit { get; set; }
    [Column("tle_idtaillemin")]
    public int IdTailleMin { get; set; }
    [Column("tle_idtaillemax")]
    public int IdTailleMax { get; set; }
    [Column("mdl_id")]
    public int IdModele { get; set; }
    [Column("catv_id")]
    public int IdCat { get; set; }
    [Column("eta_id")]
    public int IdEtat { get; set; }

    [Column("vel_nbkms")]
    public double Nbkms { get; set; }
        
    [Column("vel_prixneuf")]
    public double Prixneuf { get; set; }
        
    [Column("vel_poids")]
    public double Poids { get; set; }
        
    [Column("vel_typecadre")]
    [StringLength(50)]
    public string Typecadre { get; set; }

    [Column("vel_annee")]
    public DateTime Annee { get; set; }

    [Column("vel_bestseller")]
    public bool BestSeller { get; set; }
    [Column("vel_nbvente")]
    public int NbVente { get; set; }
    [Column("vel_qualitevelo")]
    [StringLength(250)]
    public string QualiteVelo { get; set; }

    //relation avec la table Produit
    [ForeignKey(nameof(IdProduit))]
    [InverseProperty(nameof(Produit.Velo))]
    public virtual Produit Produit { get; set; } = null!;

    //relation avec la table taille min et max
    //min
    [ForeignKey(nameof(IdTailleMin))]
    public virtual Taille TailleMin { get; set; } = null!;

    //max
    [ForeignKey(nameof(IdTailleMax))]
    public virtual Taille TailleMax { get; set; } = null!;

    //Relation avec la table modele

    [ForeignKey(nameof(IdModele))]
    public virtual Modele LeModele { get; set; } = null!;

    //Relation avec la table CategorieVelo

    [ForeignKey(nameof(IdCat))]
    public virtual CategorieVelo LaCategorie { get; set; } = null!;

    //relation avec la table etat
    [ForeignKey(nameof(IdEtat))]
    public virtual Etat Etat { get; set; } = null!;

    //relation avec la table Rapport inspection
    [InverseProperty(nameof(RapportInspection.LeVelo))]
    public virtual RapportInspection RapportInspection { get; set; }
        
    //relation est compose
    [InverseProperty(nameof(Est_Compose.LeVelo))]
    
    public virtual ICollection<Est_Compose> LesMoteurs { get; set; } = new List<Est_Compose>();

    //relation possede
    [InverseProperty(nameof(Possede.LeVelo))]
    
    public virtual ICollection<Possede> LesSousCategories { get; set; } = new List<Possede>();
    
    //relation avec la table est_caracterise
    [InverseProperty(nameof(Est_Caracterise.CaracteriseVelo))]
    
    public virtual ICollection<Est_Caracterise> Caracteristiques { get; set; } = new List<Est_Caracterise>();

    [InverseProperty(nameof(Peut_Etre_Teste.LeVelo))]
    
    public virtual ICollection<Peut_Etre_Teste> LesBoutiques { get; set; } = new List<Peut_Etre_Teste>();
    
    //relation avec la table est_mis_panier_velo
    [InverseProperty(nameof(Est_Mis_Panier_Velo.PanierVelo))]
    
    public virtual ICollection<Est_Mis_Panier_Velo> ACommandes { get; set; } =  new List<Est_Mis_Panier_Velo>();


}