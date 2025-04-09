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
    public override string ToString()
    {
        return this.Nom + " " + this.Nbkms;
    }

    protected bool Equals(VeloDtoGet other)
    {
        return IdVelo == other.IdVelo && Nom == other.Nom && UrlPhoto == other.UrlPhoto && NomMarque == other.NomMarque && PrixVelo.Equals(other.PrixVelo) && PrixNeuf.Equals(other.PrixNeuf) && TailleMax.Equals(other.TailleMax) && TailleMin.Equals(other.TailleMin) && NomModele == other.NomModele && Categorie == other.Categorie && Etat == other.Etat && Nbkms.Equals(other.Nbkms) && Poids.Equals(other.Poids) && TypeCadre == other.TypeCadre && Annee == other.Annee;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((VeloDtoGet)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(IdVelo);
        hashCode.Add(Nom);
        hashCode.Add(UrlPhoto);
        hashCode.Add(NomMarque);
        hashCode.Add(PrixVelo);
        hashCode.Add(PrixNeuf);
        hashCode.Add(TailleMax);
        hashCode.Add(TailleMin);
        hashCode.Add(NomModele);
        hashCode.Add(Categorie);
        hashCode.Add(Etat);
        hashCode.Add(Nbkms);
        hashCode.Add(Poids);
        hashCode.Add(TypeCadre);
        hashCode.Add(Annee);
        return hashCode.ToHashCode();
    }

    public VeloDtoGet(int idVelo, string nom, string urlPhoto, string nomMarque, double prixVelo, double prixNeuf, double tailleMax, double tailleMin, string nomModele, string categorie, string etat, double nbkms, double poids, string typeCadre, int annee)
    {
        IdVelo = idVelo;
        Nom = nom;
        UrlPhoto = urlPhoto;
        NomMarque = nomMarque;
        PrixVelo = prixVelo;
        PrixNeuf = prixNeuf;
        TailleMax = tailleMax;
        TailleMin = tailleMin;
        NomModele = nomModele;
        Categorie = categorie;
        Etat = etat;
        Nbkms = nbkms;
        Poids = poids;
        TypeCadre = typeCadre;
        Annee = annee;
    }
}