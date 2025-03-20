using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;



namespace SAE_G2_Upway_API.Models.DataManager;

public class CommandeManager : ICommandeRepository
{
    private readonly UpwayDBContext? upwayDbContext;


    public CommandeManager() { }

    public CommandeManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    public IQueryable<Commande> GetCommandesWithInclude()
    {
        return upwayDbContext.Commandes
                .Include(a => a.Code)
            .Include(a => a.Statut)
            .Include(a => a.ModeExpedition)
            .Include(a => a.Adresse)
            .Include(a => a.Boutique)
            .Include(a => a.AdresseFactu)
            .Include(a => a.Client)
            .Include(a => a.AssurancesPropose)
            .Include(a => a.LesSimilaires)
            .Include(a => a.LesAccessoires)
            .Include(a => a.PanierVelo)
            ;
    }


    public async Task<ActionResult<IEnumerable<Commande>>> GetAllAsync()
    {
        var commandes = await GetCommandesWithInclude().AsNoTracking().ToListAsync();
        return commandes;
    }
    public async Task<ActionResult<Commande>> GetByIdAsync(int id)
    {
        var commande = await GetCommandesWithInclude().FirstOrDefaultAsync(u => u.IdCommande == id);

        return commande;
    }
    public async Task AddAsync(Commande entity)
    {
        await upwayDbContext.Commandes.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Commande entityToUpdate, Commande entity)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        
        entityToUpdate.IdCommande = entity.IdCommande;
        entityToUpdate.DateCommande = entity.DateCommande;
        entityToUpdate.IdCode = entity.IdCode;
        entityToUpdate.IdStatut = entity.IdStatut;
        entityToUpdate.IdModeExp = entity.IdModeExp;
        entityToUpdate.IdAdresse = entity.IdAdresse;
        entityToUpdate.IdBoutique = entity.IdBoutique;
        entityToUpdate.IdAdresseFactu = entity.IdAdresseFactu;
        entityToUpdate.IdModePayement = entity.IdModePayement;
        entityToUpdate.IdClient = entity.IdClient;
    
        // Relations
        entityToUpdate.Code = entity.Code;
        entityToUpdate.Statut = entity.Statut;
        entityToUpdate.ModeExpedition = entity.ModeExpedition;
        entityToUpdate.Adresse = entity.Adresse;
        entityToUpdate.Boutique = entity.Boutique;
        entityToUpdate.AdresseFactu = entity.AdresseFactu;
        entityToUpdate.ModePayement = entity.ModePayement;
        entityToUpdate.Client = entity.Client;
    
        entityToUpdate.AssurancesPropose = entity.AssurancesPropose;
        entityToUpdate.LesSimilaires = entity.LesSimilaires;
        entityToUpdate.LesAccessoires = entity.LesAccessoires;
        entityToUpdate.PanierVelo = entity.PanierVelo;

        await upwayDbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Commande commande)
    {
        upwayDbContext.Commandes.Remove(commande);
        await upwayDbContext.SaveChangesAsync();
    }

    public async Task<ActionResult<IEnumerable<Commande>>> GetCommandesByIdClientAsync(int id)
    {
        var commandes = await GetCommandesWithInclude().Where(u=>u.IdClient == id).ToListAsync();
        return commandes;
    }
}