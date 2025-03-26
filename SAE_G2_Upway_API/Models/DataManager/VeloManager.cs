using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;


namespace SAE_G2_Upway_API.Models.DataManager;

public class VeloManager : IDataRepository<Velo, VeloDtoGet>
{
    private readonly UpwayDBContext? upwayDbContext;
    public VeloManager(){}

    public VeloManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    private IQueryable<Velo> GetVeloWithInclude()
    {
        return upwayDbContext.Velos
            .AsNoTracking()
            .Include(a => a.Produit)
            .ThenInclude(p => p.Marque)
            .Include(a => a.Produit)
            .ThenInclude(p => p.Photo)
            .Include(a => a.Produit)
            .ThenInclude(p => p.APhotos)
            .ThenInclude(ap => ap.Photo)
            .Include(a => a.TailleMin)
            .Include(a => a.TailleMax)
            .Include(a => a.LeModele)
            .Include(a => a.LaCategorie)
            .Include(a => a.Etat)
            .Include(a => a.RapportInspection)
            .ThenInclude(r => r.LesTypes)
            .Include(a => a.LesMoteurs)
            .Include(a => a.LesSousCategories)
            .ThenInclude(s => s.LaSousCategorie)
            .ThenInclude(sc => sc.Caracteristiques)
            .ThenInclude(r => r.CaracteriseVelo);
    }

    

    public async Task<ActionResult<IEnumerable<VeloDtoGet>>> GetAllAsync()
    {
        List<VeloDtoGet> velos = new List<VeloDtoGet>();

        var veloList = await GetVeloWithInclude().ToListAsync(); // Exécution ici

        foreach (var velo in veloList) // Maintenant, c'est une liste en mémoire
        {
            velos.Add(new VeloDtoGet(velo));
        }
    
        return velos;
        //return await GetVeloWithInclude().ToListAsync();
    }
    public async Task<ActionResult<Velo>> GetByIdAsync(int id)
    {
        var velo = await GetVeloWithInclude()
            .FirstOrDefaultAsync(u => u.IdVelo == id);
        var velocarac = upwayDbContext.Velos.Include(a => a.Caracteristiques).FirstOrDefault(u => u.IdVelo == id).Caracteristiques;
        foreach (var possede in velo.LesSousCategories)
        {
            
            foreach (var carac in possede.LaSousCategorie.Caracteristiques) 
            {
                carac.CaracteriseVelo = new List<Est_Caracterise>();
                foreach (var vc in velocarac)
                {
                    if (vc.IdCaract == carac.IdCaract)
                    {
                        carac.CaracteriseVelo.Add(vc);
                       
                    }
                }
            }
            
        }
        return velo;
    }
    

   
    
    public async Task AddAsync(Velo entity)
    {
        await upwayDbContext.Velos.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Velo entityToUpdate, Velo entity)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        entityToUpdate.IdVelo = entity.IdVelo;
        entityToUpdate.IdProduit = entity.IdProduit;
        entityToUpdate.IdTailleMin = entity.IdTailleMin;
        entityToUpdate.IdTailleMax = entity.IdTailleMax;
        entityToUpdate.IdModele = entity.IdModele;
        entityToUpdate.IdCat = entity.IdCat;
        entityToUpdate.IdEtat = entity.IdEtat;
        entityToUpdate.Nbkms = entity.Nbkms;
        entityToUpdate.Prixneuf = entity.Prixneuf;
        entityToUpdate.Poids = entity.Poids;
        entityToUpdate.Typecadre = entity.Typecadre;
        entityToUpdate.Annee = entity.Annee;
        entityToUpdate.BestSeller = entity.BestSeller;
        entityToUpdate.NbVente = entity.NbVente;
        entityToUpdate.QualiteVelo = entity.QualiteVelo;
        
        
        

        await upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Velo velo)
    {
        upwayDbContext.Velos.Remove(velo);
        await upwayDbContext.SaveChangesAsync();
    }
}