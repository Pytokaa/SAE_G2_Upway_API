using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using SAE_G2_Upway_API.Controllers.DTO;

namespace SAE_G2_Upway_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandesController : ControllerBase
{
    private readonly ICommandeRepository dataRepository;

    public CommandesController(ICommandeRepository dataRepo)
    {
        dataRepository = dataRepo;        
    }
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
    {
        return await dataRepository.GetAllAsync();
    }
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Commande>> GetCommandeById(int id)
    {
        var commande = await dataRepository.GetByIdAsync(id);
        
        
        
        if (commande.Value == null)
        {
            return NotFound();
        }

        return commande;
    }
    
    [HttpPut("id/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutCommande(int id, CommandeDTO commandeDTO)
    {
        var commandeToUpdate = await dataRepository.GetByIdAsync(id);

        if (commandeToUpdate == null)
        {
            return NotFound();
        }
        Commande commande = new Commande(commandeDTO);

        
        dataRepository.UpdateAsync(commandeToUpdate.Value, commande);
        return NoContent();
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Commande>> PostCommande(CommandeDTO commandeDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Commande commande = new Commande(commandeDTO);
        await dataRepository.AddAsync(commande);
        return CreatedAtAction("GetAccessoireById", new { id = commande.IdCommande }, commande);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteCommande(int id)
    {
        var commande = await dataRepository.GetByIdAsync(id);
        if (commande == null)
        {
            return NotFound();
        }

        

        await dataRepository.DeleteAsync(commande.Value);
        return NoContent();
    }

    [HttpGet("/clientId/{id}")]
    public async Task<ActionResult<IEnumerable<Commande>>> GetCommandesByClientId(int id)
    {
        var commandes = await dataRepository.GetCommandesByIdClientAsync(id);
        return commandes;
    }
    
}