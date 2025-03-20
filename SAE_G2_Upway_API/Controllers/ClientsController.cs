using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using SAE_G2_Upway_API.Controllers.DTO;
namespace SAE_G2_Upway_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IDataRepository<Client, Client> dataRepository;

    public ClientsController(IDataRepository<Client, Client> dataRepo)
    {
        dataRepository = dataRepo;
    }

    /// <summary>
    /// R�cup�rer la liste de tous les clients.
    /// </summary>
    /// <returns>Une r�ponse HTTP avec la liste de tous les clients.</returns>
    /// <response code="200">Renvoie tous les clients avec succ�s.</response>
    /// <response code="500">Erreur interne du serveur.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await dataRepository.GetAllAsync();
    }
    // GET: api/Client/5
    /// <summary>
    /// R�cup�rer un client par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du client.</param>
    /// <returns>Une r�ponse HTTP avec le client trouv� ou une erreur si non trouv�.</returns>
    /// <response code="200">Le client a �t� trouv� et renvoy� avec succ�s.</response>
    /// <response code="404">Le client avec l'identifiant sp�cifi� n'a pas �t� trouv�.</response>
    /// <response code="500">Erreur interne du serveur lors de la r�cup�ration du client.</response>
    [HttpGet("id/{id}")]
    public async Task<ActionResult<Client>> GetClientById(int id)
    {
        var client = await dataRepository.GetByIdAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }
    /// <summary>
    /// R�cup�rer un client par son nom.
    /// </summary>
    /// <param name="nom">Le nom du client.</param>
    /// <returns>Une r�ponse HTTP avec le client trouv� ou une erreur si non trouv�.</returns>
    /// <response code="200">Le client a �t� trouv� et renvoy� avec succ�s.</response>
    /// <response code="404">Aucun client avec le nom sp�cifi� n'a �t� trouv�.</response>
    /// <response code="500">Erreur interne du serveur lors de la r�cup�ration du client.</response>
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
    /// Mettre � jour un client en fonction de son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du client � mettre � jour.</param>
    /// <param name="client">Les donn�es du client � mettre � jour.</param>
    /// <returns>Une r�ponse HTTP indiquant le succ�s ou l'�chec de la mise � jour.</returns>
    /// <response code="204">Le client a �t� mis � jour avec succ�s.</response>
    /// <response code="400">L'identifiant du client dans l'URL ne correspond pas � celui du client pass� dans le corps de la requ�te.</response>
    /// <response code="404">Le client avec l'identifiant sp�cifi� n'a pas �t� trouv�.</response>
    /// <response code="500">Erreur interne du serveur lors de la mise � jour du client.</response>
    [HttpPut("id/{id}")]
    public async Task<IActionResult> PutClient(int id, ClientDTO clientDto)
    {
        var clientToUpdate = await dataRepository.GetByIdAsync(id);
        if (clientToUpdate == null)
        {
            return NotFound();
        }

        if (clientToUpdate.Value.IdFonction < 0 || clientToUpdate.Value.IdFonction == null)
        {
            return BadRequest();
        }

        Client client = new Client(clientDto);

        dataRepository.UpdateAsync(clientToUpdate.Value, client);
        return NoContent();
    }

    // POST: api/Client
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Ajouter un nouveau client.
    /// </summary>
    /// <param name="client">Les informations du client � ajouter.</param>
    /// <returns>Une r�ponse HTTP avec le client cr�� ou une erreur si la validation �choue.</returns>
    /// <response code="201">Le client a �t� cr�� avec succ�s.</response>
    /// <response code="400">Les donn�es envoy�es ne sont pas valides.</response>
    /// <response code="500">Erreur interne du serveur lors de l'ajout du client.</response>
    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(ClientDTO clientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Client client = new Client()
        {
            Nomclient = clientDto.Nom,
            Prenomclient = clientDto.Prenom,
            Mailclient = clientDto.Mail,
            Telephone = clientDto.Telephone,
            IdFonction = clientDto.IdFonction,
            Password = clientDto.Password,
            UserRole = clientDto.UserRole
        };
        await dataRepository.AddAsync(client);
        return CreatedAtAction("GetAccessoireById", new { id = client.Idclient },client);
    }





    // DELETE: api/Client/5
    /// <summary>
    /// Supprimer un client en fonction de son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du client � supprimer.</param>
    /// <returns>Une r�ponse HTTP indiquant le succ�s ou l'�chec de la suppression.</returns>
    /// <response code="204">Le client a �t� supprim� avec succ�s.</response>
    /// <response code="404">Le client avec l'identifiant sp�cifi� n'a pas �t� trouv�.</response>
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