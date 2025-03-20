using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Models.DataManager;

public class ClientManager : IDataRepository<Client, Client>
{
    private readonly UpwayDBContext upwayDbContext;
    public ClientManager(){}

    public ClientManager(UpwayDBContext? context)
    {
        upwayDbContext = context;
    }

    private IQueryable<Client> GetClientWithInclude()
    {
        return upwayDbContext.Clients
            .Include(a => a.Fonction)
            .Include(a => a.Alertes)
            .Include(a => a.Commandes)
            .Include(a => a.LesFavoris)
            .Include(a => a.HabiteA);
    }

    public async Task<ActionResult<IEnumerable<Client>>> GetAllAsync()
    {
        return await GetClientWithInclude().ToListAsync();
    }

    public async Task<ActionResult<Client>> GetByIdAsync(int id)
    {
        var client = await GetClientWithInclude().FirstOrDefaultAsync(u => u.Idclient == id);
        return client;
    }
    public async Task<ActionResult<Client>> GetByStringAsync(string nomclient)
    {
        var client = await GetClientWithInclude()
            .FirstOrDefaultAsync(u => u.Nomclient == nomclient);

        return client;
    }
    public async Task AddAsync(Client entity)
    {
        await upwayDbContext.Clients.AddAsync(entity);
        await upwayDbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Client entityToUpdate, Client client)
    {
        upwayDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        
        
        entityToUpdate.Idclient = client.Idclient;
        entityToUpdate.IdFonction = client.IdFonction;
        entityToUpdate.Nomclient = client.Nomclient;
        entityToUpdate.Prenomclient = client.Prenomclient;
        entityToUpdate.Mailclient = client.Mailclient;
        entityToUpdate.Telephone = client.Telephone;
        entityToUpdate.Password = client.Password;
        
        //relations
        
        entityToUpdate.Fonction = client.Fonction;
        entityToUpdate.Commandes = client.Commandes;
        entityToUpdate.LesFavoris = client.LesFavoris;
        entityToUpdate.HabiteA = client.HabiteA;

        await upwayDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Client client)
    {
        upwayDbContext.Clients.Remove(client);
        await upwayDbContext.SaveChangesAsync();
    }
}