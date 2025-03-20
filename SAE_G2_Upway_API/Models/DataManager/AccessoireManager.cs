using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;


namespace SAE_G2_Upway_API.Models.DataManager;

public class AccessoireManager : IDataRepository<Accessoire, AccessoireDtoGet>
{
    private readonly UpwayDBContext? upwayDbContext;
    public AccessoireManager(){}

    public AccessoireManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    private IQueryable<Accessoire> GetAccessoireWithInclude()
    {
        return upwayDbContext.Accessoires
            .Include(a => a.Produit)
            .ThenInclude(p=>p.Marque)
            .Include(a => a.Produit)
            .ThenInclude(p=>p.Photo)
            .Include(a => a.CategorieAccessoire)
            .Include(a => a.LesCommandes)
            .Include(a => a.LesCommandesAccessoire);
    }
    
    public async Task<ActionResult<IEnumerable<AccessoireDtoGet>>> GetAllAsync()
    {
        List<AccessoireDtoGet> accessoires = new List<AccessoireDtoGet>();

        var accessoiresList = await GetAccessoireWithInclude().ToListAsync(); // Exécution ici

        foreach (var acc in accessoiresList) // Maintenant, c'est une liste en mémoire
        {
            accessoires.Add(new AccessoireDtoGet()
            {
                Nom = acc.Produit.NomProduit,
                Prix = acc.Produit.PrixProduit,
                Url = acc.Produit.Photo.Url,
                Marque = acc.Produit.Marque.NomMarque,
                Categorie = acc.CategorieAccessoire.NomCatA,
                DateAccessoire = acc.DateAccessoire,
            });
        }
    
        return accessoires;
    }

    public async Task<ActionResult<Accessoire>> GetByIdAsync(int id)
    {
        var accessoire = await GetAccessoireWithInclude().FirstOrDefaultAsync(u => u.IdAccessoire == id);

        return accessoire;
    }

    public async Task<ActionResult<Accessoire>> GetByStringAsync(string nomaccessoire)
    {
        var accessoire = await GetAccessoireWithInclude()
            .FirstOrDefaultAsync(u => u.Produit.NomProduit == nomaccessoire);

        return accessoire;
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
        entityToUpdate.IdCatA = entity.IdCatA;
        entityToUpdate.DateAccessoire = entity.DateAccessoire;
        
        //relations
        entityToUpdate.IdProduit = entity.IdProduit;        

        await upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Accessoire accessoire)
    {
        upwayDbContext.Accessoires.Remove(accessoire);
        await upwayDbContext.SaveChangesAsync();
    }
}