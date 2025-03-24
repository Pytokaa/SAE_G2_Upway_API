namespace SAE_G2_Upway_API.Models.EntityFramework;

public partial class Accessoire
{
    public override bool Equals(object? obj)
    {
        return obj is Accessoire accessoire &&
               IdAccessoire == accessoire.IdAccessoire &&
               IdProduit == accessoire.IdProduit &&
               IdCatA == accessoire.IdCatA &&
               DateAccessoire == accessoire.DateAccessoire;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(IdAccessoire);
        hash.Add(IdProduit);
        hash.Add(IdCatA);
        hash.Add(DateAccessoire);
        hash.Add(LesCommandes);
        hash.Add(LesCommandesAccessoire);
        return hash.ToHashCode();
    }

    public Accessoire(int idAccessoire, int idProduit, int idCatA, DateTime dateAccessoire, 
        ICollection<Est_Propose_Similaire> lesCommandes, 
        ICollection<Est_Mis_Panier_Accessoire> lesCommandesAccessoire)
    {
        IdAccessoire = idAccessoire;
        IdProduit = idProduit;
        IdCatA = idCatA;
        DateAccessoire = dateAccessoire;
        LesCommandes = lesCommandes;
        LesCommandesAccessoire = lesCommandesAccessoire;
    }

    public Accessoire(int idAccessoire, int idProduit, int idCatA, DateTime dateAccessoire)
    {
        IdAccessoire = idAccessoire;
        IdProduit = idProduit;
        IdCatA = idCatA;
        DateAccessoire = dateAccessoire;
    }
}