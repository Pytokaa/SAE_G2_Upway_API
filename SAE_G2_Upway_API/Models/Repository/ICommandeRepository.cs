using Microsoft.AspNetCore.Mvc;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

public interface ICommandeRepository : IDataRepository<Commande, Commande>
{
    Task<ActionResult<IEnumerable<Commande>>> GetCommandesByIdClientAsync(int clientId);
}