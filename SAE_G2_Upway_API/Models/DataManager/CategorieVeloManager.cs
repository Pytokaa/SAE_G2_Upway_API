using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Models.DataManager;

public class CategorieVeloManager : IDataRepository<CategorieVelo, CategorieVelo>
{
    private readonly UpwayDBContext? upwayDbContext;
    public CategorieVeloManager(){}

    public CategorieVeloManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    public async Task<ActionResult<IEnumerable<CategorieVelo>>> GetAllAsync()
    {
        var cateVelo = upwayDbContext.CategorieVelos.ToList();
        return cateVelo;
    }
    
    public async Task<ActionResult<CategorieVelo>> GetByIdAsync(int id)
    {
        var cateVelo = upwayDbContext.CategorieVelos.FirstOrDefault(u => u.IdCat == id);
        return cateVelo;
    }

    public async Task AddAsync(CategorieVelo entity)
    {
        await upwayDbContext.CategorieVelos.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(CategorieVelo entityToUpdate, CategorieVelo entity)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;

        entityToUpdate.IdCat = entity.IdCat;
        entityToUpdate.NomCategorie = entity.NomCategorie;

        await upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(CategorieVelo cateVelo)
    {
        upwayDbContext.CategorieVelos.Remove(cateVelo);
        await upwayDbContext.SaveChangesAsync();
    } 
}