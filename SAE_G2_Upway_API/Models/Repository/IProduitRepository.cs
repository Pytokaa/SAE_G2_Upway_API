using SAE_G2_Upway_API.Models.EntityFramework;

namespace SAE_G2_Upway_API.Models.Repository;

public interface IProduitRepository : IDataRepository<Produit>
{
    Task<bool> ExistsAsync(int id);
}