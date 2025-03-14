using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
namespace SAE_G2_Upway_API.Controllers;


public class ClientsController : ControllerBase
{
    private readonly IDataRepository<Client> dataRepository;

    public ClientsController(IDataRepository<Client> dataRepo)
    {
        dataRepository = dataRepo;
    }
    
    // GET: api/Client
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await dataRepository.GetAllAsync();
    }
    // GET: api/Client/5
    [HttpGet("id/{id}")]
    public async Task<ActionResult<Client>> GetClientById(int id)
    {
        var client = dataRepository.GetByIdAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client.Result;
    }
    
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