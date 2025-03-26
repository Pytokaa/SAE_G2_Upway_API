using SAE_G2_Upway_API.Models.EntityFramework;

namespace SAE_G2_Upway_API.Controllers.DTO.DtoGet;

public class VeloDtoGet
{
    public int IdVelo { get; set; }
    public string Nom { get; set; }
    public string UrlPhoto { get; set; }
    public string NomMarque { get; set; }
    public double PrixVelo { get; set; }
    public double PrixNeuf { get; set; }
    public double TailleMax { get; set; }
    public double TailleMin { get; set; }
    public string NomModele { get; set; }
    public string Categorie { get; set; }
    public string Etat { get; set; }
    public double Nbkms { get; set; }
    public double Poids { get; set; }
    public string TypeCadre { get; set; }
    public int Annee { get; set; }
    public bool BestSeller { get; set; }
    public RapportInspection RapportInspection { get; set; }
    public ICollection<A_Pour_Photo> LesPhotos { get; set; }
    
    
    public VeloDtoGet(Velo velo)
    {
        this.IdVelo = velo.IdVelo;
        this.Nom = velo.Produit.NomProduit;
        this.UrlPhoto = velo.Produit.Photo.Url;
        this.NomMarque = velo.Produit.Marque.NomMarque;
        this.PrixVelo = velo.Produit.PrixProduit;
        this.PrixNeuf = velo.Prixneuf;
        this.TailleMax = velo.TailleMax.TailleCm;
        this.TailleMin = velo.TailleMin.TailleCm;
        this.NomModele = velo.LeModele.NomModele;
        this.Categorie = velo.LaCategorie.NomCategorie;
        this.Etat = velo.Etat.NomEtat;
        this.Nbkms = velo.Nbkms;
        this.Poids = velo.Poids;
        this.TypeCadre = velo.Typecadre;
        this.Annee = velo.Annee;
        this.BestSeller = velo.BestSeller;
    }

    public VeloDtoGet(Velo velo, bool test)
    {
        this.Nom = "velo.Produit.NomProduit";
        this.UrlPhoto = "velo.Produit.Photo.Url";
        this.NomMarque = "velo.Produit.Marque.NomMarque";
        this.PrixVelo = 1;
        this.PrixNeuf = velo.Prixneuf;
        this.TailleMax = 1;
        this.TailleMin = 1;
        this.NomModele = "velo.LeModele.NomModele";
        this.Categorie = "velo.LaCategorie.NomCategorie";
        this.Etat = "velo.Etat.NomEtat";
        this.Nbkms = velo.Nbkms;
        this.Poids = velo.Poids;
        this.TypeCadre = velo.Typecadre;
        this.Annee = velo.Annee;
        this.BestSeller = velo.BestSeller;
    }
    public VeloDtoGet() { }
}