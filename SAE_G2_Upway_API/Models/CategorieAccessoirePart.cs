
namespace SAE_G2_Upway_API.Models.EntityFramework;

public partial class CategorieAccessoire
{
    public CategorieAccessoire(int id, string name) 
    {
        IdCatA = id;
        NomCatA = name;
    }

    public override bool Equals(object? obj)
    {
        return obj is CategorieAccessoire accessoire &&
               IdCatA == accessoire.IdCatA &&
               NomCatA == accessoire.NomCatA;
    }
    public CategorieAccessoire(){}

    public override int GetHashCode()
    {
        return HashCode.Combine(IdCatA, NomCatA);
    }
}
