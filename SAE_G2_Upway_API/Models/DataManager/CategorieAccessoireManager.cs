using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Models.DataManager;

public class CategorieAccessoireManager : IDataRepository<CategorieAccessoire, CategorieAccessoire>
{
    private readonly UpwayDBContext? upwayDbContext;

    public CategorieAccessoireManager() { }

    public CategorieAccessoireManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }
    public async Task<ActionResult<IEnumerable<CategorieAccessoire>>> GetAllAsync()
    {
        var cateAcce = upwayDbContext.CategorieAccessoires.ToList();
        return cateAcce;
    }
    
    public async Task<ActionResult<CategorieAccessoire>> GetByIdAsync(int id)
    {
        var cateAcce = upwayDbContext.CategorieAccessoires.FirstOrDefault(u => u.IdCatA == id);
        return cateAcce;
    }

    public async Task AddAsync(CategorieAccessoire entity)
    {
        await upwayDbContext.CategorieAccessoires.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(CategorieAccessoire entityToUpdate, CategorieAccessoire entity)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;

        entityToUpdate.IdCatA= entity.IdCatA;
        entityToUpdate.NomCatA = entity.NomCatA;

        await upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(CategorieAccessoire cateAcce)
    {
        upwayDbContext.CategorieAccessoires.Remove(cateAcce);
        await upwayDbContext.SaveChangesAsync();
    } 
}