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
            .ThenInclude(p=>p.Marque)
            .Include(a => a.Produit)
            .ThenInclude(p => p.Photo)
            .Include(a => a.TailleMin)
            .Include(a => a.TailleMax)
            .Include(a => a.LeModele)
            .Include(a => a.LaCategorie)
            .Include(a => a.Etat)
            .Include(a => a.RapportInspection)
            .Include(a => a.LesMoteurs)
            .Include(a => a.LesSousCategories)
            .Include(a => a.Caracteristiques)
            .Include(a => a.LesBoutiques)
            .Include(a => a.ACommandes);
    }
    

    public async Task<ActionResult<IEnumerable<VeloDtoGet>>> GetAllAsync()
    {
        List<VeloDtoGet> velos = new List<VeloDtoGet>();

        var veloList = await GetVeloWithInclude().ToListAsync(); // Exécution ici

        foreach (var velo in veloList) // Maintenant, c'est une liste en mémoire
        {
            velos.Add(new VeloDtoGet()
            {
                Nom = velo.Produit.NomProduit,
                UrlPhoto = velo.Produit.Photo.Url,
                NomMarque = velo.Produit.Marque.NomMarque,
                PrixVelo = velo.Produit.PrixProduit,
                PrixNeuf = velo.Prixneuf,
                TailleMax = velo.TailleMax.TailleCm,
                TailleMin = velo.TailleMin.TailleCm,
                NomModele = velo.LeModele.NomModele,
                Categorie = velo.LaCategorie.NomCategorie,
                Etat = velo.Etat.NomEtat,
                Nbkms = velo.Nbkms,
                Poids = velo.Poids,
                TypeCadre = velo.Typecadre,
                Annee = velo.Annee,
                BestSeller = velo.BestSeller,
            });
        }
    
        return velos;
        //return await GetVeloWithInclude().ToListAsync();
    }
    public async Task<ActionResult<Velo>> GetByIdAsync(int id)
    {
        var velo = await GetVeloWithInclude()
            .FirstOrDefaultAsync(u => u.IdVelo == id);

        return velo;
    }
    

    public async Task<ActionResult<Velo>> GetByStringAsync(string nomvelo)
    {
        var velo = await GetVeloWithInclude()
            .FirstOrDefaultAsync(u => u.Produit.NomProduit == nomvelo);

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
        
        //relations
        
        entityToUpdate.Produit = entity.Produit;
        entityToUpdate.TailleMin = entity.TailleMin;
        entityToUpdate.TailleMax = entity.TailleMax;
        entityToUpdate.LeModele  = entity.LeModele;
        entityToUpdate.LaCategorie = entity.LaCategorie;
        entityToUpdate.Etat = entity.Etat;
        entityToUpdate.RapportInspection = entity.RapportInspection;
        entityToUpdate.LesMoteurs = entity.LesMoteurs;
        entityToUpdate.LesSousCategories = entity.LesSousCategories;
        entityToUpdate.Caracteristiques = entity.Caracteristiques;
        entityToUpdate.LesBoutiques = entity.LesBoutiques;
        entityToUpdate.ACommandes = entity.ACommandes;

        await upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Velo velo)
    {
        upwayDbContext.Velos.Remove(velo);
        await upwayDbContext.SaveChangesAsync();
    }
}