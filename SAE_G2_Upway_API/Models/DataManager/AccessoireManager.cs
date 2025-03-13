using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;


namespace SAE_G2_Upway_API.Models.DataManager;

public class AccessoireManager : IDataRepository<Accessoire>
{
    private readonly UpwayDBContext? upwayDbContext;
    public AccessoireManager(){}

    public AccessoireManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }
    
    public ActionResult<IEnumerable<Accessoire>> GetAll()
    {
        return upwayDbContext.Accessoires.ToList();
    }

    public async Task<ActionResult<Accessoire>> GetByIdAsync(int id)
    {
        return upwayDbContext.Accessoires.FirstOrDefault(u => u.IdAccessoire == id);
    }

    public async Task<ActionResult<Accessoire>> GetByStringAsync(string nomvelo)
    {
        return await upwayDbContext.Accessoires.FirstOrDefaultAsync(u => u.Produit.NomProduit == nomvelo);
    }
    
    public async Task AddAsync(Accessoire entity)
    {
        await upwayDbContext.Accessoires.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Accessoire entityToUpdate, Accessoire entity)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        
        entityToUpdate.IdAccessoire = entity.IdAccessoire;
        entityToUpdate.IdProduit = entity.IdProduit;
        entityToUpdate.IdCatA = entity.IdCatA;
        entityToUpdate.DateAccessoire = entity.DateAccessoire;
        
        //relations
        entityToUpdate.Produit = entity.Produit;
        entityToUpdate.CategorieAccessoire = entity.CategorieAccessoire;
        entityToUpdate.LesCommandes = entity.LesCommandes;
        entityToUpdate.LesCommandesAccessoire = entity.LesCommandesAccessoire;

        upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Accessoire accessoire)
    {
        upwayDbContext.Accessoires.Remove(accessoire);
        upwayDbContext.SaveChangesAsync();
    }
}