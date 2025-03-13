using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;


namespace SAE_G2_Upway_API.Models.DataManager;

public class VeloManager : IDataRepository<Velo>
{
    private readonly UpwayDBContext? upwayDbContext;
    public VeloManager(){}

    public VeloManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    public ActionResult<IEnumerable<Velo>> GetAll()
    {
        return upwayDbContext.Velos.ToList();
    }

    public async Task<ActionResult<Velo>> GetByIdAsync(int id)
    {
        return upwayDbContext.Velos.FirstOrDefault(u => u.IdVelo == id);
    }

    public async Task<ActionResult<Velo>> GetByStringAsync(string nomvelo)
    {
        return await upwayDbContext.Velos.FirstOrDefaultAsync(u => u.Produit.NomProduit == nomvelo);
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

        upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Velo velo)
    {
        upwayDbContext.Velos.Remove(velo);
        upwayDbContext.SaveChangesAsync();
    }
}