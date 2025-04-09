
namespace SAE_G2_Upway_API.Models.EntityFramework;

public partial class CategorieVelo
{
    public CategorieVelo(int id, string name)
    {
        IdCat = id;
        NomCategorie = name;
    }

    public override bool Equals(object? obj)
    {
        return obj is CategorieVelo Velo &&
               IdCat == Velo.IdCat &&
               NomCategorie == Velo.NomCategorie;
    }
    public CategorieVelo() { }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdCat, NomCategorie);
    }
}
