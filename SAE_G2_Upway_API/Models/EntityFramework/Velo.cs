using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


// il faut ajouter encore les liens vers les autres tables lorsqu'elle seront créées
namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("velo")]
public partial class Velo
{
    [Key]
    [Column("idvelo", TypeName ="integer")]
    public int IdVelo { get; set; }

    [Column("idproduit")]
    public int IdProduit { get; set; }
    [Column("idtaillemin")]
    public int IdTailleMin { get; set; }
    [Column("idtaillemax")]
    public int IdTailleMax { get; set; }
    [Column("idmodele")]
    public int IdModele { get; set; }
    [Column("idcat")]
    public int IdCat { get; set; }
    [Column("idetat")]
    public int IdEtat { get; set; }

    [Column("nbkms")]
    public double Nbkms { get; set; }
        
    [Column("prixneuf")]
    public double Prixneuf { get; set; }
        
    [Column("poids")]
    public double Poids { get; set; }
        
    [Column("typecadre")]
    [StringLength(50)]
    public string Typecadre { get; set; }

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