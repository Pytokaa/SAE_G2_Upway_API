namespace SAE_G2_Upway_API.Models.EntityFramework;

public partial class Produit
{
    public override bool Equals(object? obj)
    {
        return obj is Produit produit &&
               Idproduit == produit.Idproduit &&
               IdPhoto == produit.IdPhoto &&
               IdMarque == produit.IdMarque &&
               NomProduit == produit.NomProduit &&
               PrixProduit == produit.PrixProduit &&
               StockProduit == produit.StockProduit &&
               DescriptionProduit == produit.DescriptionProduit;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(Idproduit);
        hash.Add(IdPhoto);
        hash.Add(IdMarque);
        hash.Add(NomProduit);
        hash.Add(PrixProduit);
        hash.Add(StockProduit);
        hash.Add(DescriptionProduit);
        hash.Add(DansLesFavoris);
        hash.Add(APhotos);
        return hash.ToHashCode();
    }

    public Produit(int idproduit, int idPhoto, int idMarque, string nomProduit, double prixProduit,
        int stockProduit, string descriptionProduit, ICollection<Est_En_Favoris> dansLesFavoris,
        ICollection<A_Pour_Photo> aPhotos)
    {
        Idproduit = idproduit;
        IdPhoto = idPhoto;
        IdMarque = idMarque;
        NomProduit = nomProduit;
        PrixProduit = prixProduit;
        StockProduit = stockProduit;
        DescriptionProduit = descriptionProduit;
        DansLesFavoris = dansLesFavoris;
        APhotos = aPhotos;
    }

    public Produit(int idproduit, int idPhoto, int idMarque, string nomProduit, double prixProduit, int stockProduit, string descriptionProduit)
    {
        Idproduit = idproduit;
        IdPhoto = idPhoto;
        IdMarque = idMarque;
        NomProduit = nomProduit;
        PrixProduit = prixProduit;
        StockProduit = stockProduit;
        DescriptionProduit = descriptionProduit;
    }
   public Produit() { }
}