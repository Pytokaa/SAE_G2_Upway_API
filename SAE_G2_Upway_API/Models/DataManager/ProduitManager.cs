using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;



namespace SAE_G2_Upway_API.Models.DataManager;

public class ProduitManager : IDataRepository<Produit>
{
    private readonly UpwayDBContext? upwayDbContext;
    public ProduitManager(){}

    public ProduitManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    private IQueryable<Produit> GetProduitWithInclude()
    {
        Console.WriteLine("Applying AsNoTracking to query...");
        return upwayDbContext.Produits 
            .AsTracking()
            .Include(a => a.Photo)
            .Include(a => a.Marque)
            .Include(a => a.Accessoire)
            .Include(a => a.Velo)
            .Include(a => a.DansLesFavoris)
            .Include(a => a.APhotos);
    }
    public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
    {
        return await GetProduitWithInclude().ToListAsync();
    }

    public async Task<ActionResult<Produit>> GetByIdAsync(int id)
    {
        Console.WriteLine("GetById");
        var produit = await GetProduitWithInclude().FirstOrDefaultAsync(u => u.Idproduit == id);
        return produit;
    }

    public async Task<ActionResult<Produit>> GetByStringAsync(string name)
    {
        var produit = await GetProduitWithInclude()
            .FirstOrDefaultAsync(u => u.NomProduit == name);
        return produit;
    }

    public async Task AddAsync(Produit entity)
    {
        await upwayDbContext.Produits.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produit entityToUpdate, Produit entity)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        
        entityToUpdate.Idproduit = entity.Idproduit;
        entityToUpdate.NomProduit = entity.NomProduit;
        entityToUpdate.PrixProduit = entity.PrixProduit;
        entityToUpdate.DescriptionProduit = entity.DescriptionProduit;
        entityToUpdate.StockProduit = entity.StockProduit;
        
        //relations
        
        entityToUpdate.IdMarque = entity.IdMarque;
        entityToUpdate.IdPhoto = entity.IdPhoto;
        
        await upwayDbContext.SaveChangesAsync();
    }




    public async Task DeleteAsync(Produit produit)
    {
        upwayDbContext.Produits.Remove(produit);
        await upwayDbContext.SaveChangesAsync();
    }
    
}