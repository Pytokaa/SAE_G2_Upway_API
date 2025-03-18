using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
namespace SAE_G2_Upway_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IDataRepository<Client> dataRepository;

    public ClientsController(IDataRepository<Client> dataRepo)
    {
        dataRepository = dataRepo;
    }

    /// <summary>
    /// Récupérer la liste de tous les clients.
    /// </summary>
    /// <returns>Une réponse HTTP avec la liste de tous les clients.</returns>
    /// <response code="200">Renvoie tous les clients avec succès.</response>
    /// <response code="500">Erreur interne du serveur.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await dataRepository.GetAllAsync();
    }
    // GET: api/Client/5
    /// <summary>
    /// Récupérer un client par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du client.</param>
    /// <returns>Une réponse HTTP avec le client trouvé ou une erreur si non trouvé.</returns>
    /// <response code="200">Le client a été trouvé et renvoyé avec succès.</response>
    /// <response code="404">Le client avec l'identifiant spécifié n'a pas été trouvé.</response>
    /// <response code="500">Erreur interne du serveur lors de la récupération du client.</response>
    [HttpGet("id/{id}")]
    public async Task<ActionResult<Client>> GetClientById(int id)
    {
        var client = await dataRepository.GetByIdAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client.Result;
    }
    /// <summary>
    /// Récupérer un client par son nom.
    /// </summary>
    /// <param name="nom">Le nom du client.</param>
    /// <returns>Une réponse HTTP avec le client trouvé ou une erreur si non trouvé.</returns>
    /// <response code="200">Le client a été trouvé et renvoyé avec succès.</response>
    /// <response code="404">Aucun client avec le nom spécifié n'a été trouvé.</response>
    /// <response code="500">Erreur interne du serveur lors de la récupération du client.</response>
    [HttpGet("name/{nom}")]
    [ActionName("GetByClientName")]
    public async Task<ActionResult<Client>> GetClientByName(string nom)
    {
        var client = await dataRepository.GetByStringAsync(nom);
        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    // PUT: api/Client/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Mettre à jour un client en fonction de son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du client à mettre à jour.</param>
    /// <param name="client">Les données du client à mettre à jour.</param>
    /// <returns>Une réponse HTTP indiquant le succès ou l'échec de la mise à jour.</returns>
    /// <response code="204">Le client a été mis à jour avec succès.</response>
    /// <response code="400">L'identifiant du client dans l'URL ne correspond pas à celui du client passé dans le corps de la requête.</response>
    /// <response code="404">Le client avec l'identifiant spécifié n'a pas été trouvé.</response>
    /// <response code="500">Erreur interne du serveur lors de la mise à jour du client.</response>
    [HttpPut("id/{id}")]
    public async Task<IActionResult> PutClient(int id, Client client)
    {
        if (id != client.Idclient)
        {
            return BadRequest();
        }

        var clientToUpdate = dataRepository.GetByIdAsync(id);

        if (clientToUpdate == null)
        {
            return NotFound();
        }
        else
        {
            dataRepository.UpdateAsync(clientToUpdate.Result.Value, client);
            return NoContent();
        }

        return NoContent();
    }

    // POST: api/Client
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Ajouter un nouveau client.
    /// </summary>
    /// <param name="client">Les informations du client à ajouter.</param>
    /// <returns>Une réponse HTTP avec le client créé ou une erreur si la validation échoue.</returns>
    /// <response code="201">Le client a été créé avec succès.</response>
    /// <response code="400">Les données envoyées ne sont pas valides.</response>
    /// <response code="500">Erreur interne du serveur lors de l'ajout du client.</response>
    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(Client client)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await dataRepository.AddAsync(client);
        return CreatedAtAction("GetAccessoireById", new { id = client.Idclient },client);
    }





    // DELETE: api/Client/5
    /// <summary>
    /// Supprimer un client en fonction de son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du client à supprimer.</param>
    /// <returns>Une réponse HTTP indiquant le succès ou l'échec de la suppression.</returns>
    /// <response code="204">Le client a été supprimé avec succès.</response>
    /// <response code="404">Le client avec l'identifiant spécifié n'a pas été trouvé.</response>
    /// <response code="500">Erreur interne du serveur lors de la suppression du client.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await dataRepository.GetByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }

            
        await dataRepository.DeleteAsync(client.Value);
        return NoContent();
    }
    
    
    

}