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
    public async Task<ActionResult<IEnumerable<Commande>>> GetAccessoires()
    {
        return await dataRepository.GetAllAsync();
    }
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Commande>> GetAccessoireById(int id)
    {
        var commande = await dataRepository.GetByIdAsync(id);
        
        
        
        if (commande == null)
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
        Commande commande = new Commande()
        {
            DateCommande = commandeDTO.DateCommande,
            IdCode = commandeDTO.IdCode,
            IdStatut = commandeDTO.IdStatut,
            IdModeExp = commandeDTO.IdModeExp,
            IdAdresse = commandeDTO.IdAdresse,
            IdBoutique = commandeDTO.IdBoutique,
            IdAdresseFactu = commandeDTO.IdAdresseFactu,
            IdModePayement = commandeDTO.IdModePayement,
            IdClient = commandeDTO.IdClient,
        };

        var commandeToUpdate = dataRepository.GetByIdAsync(id);

        if (commandeToUpdate == null)
        {
            return NotFound();
        }
        dataRepository.UpdateAsync(commandeToUpdate.Result.Value, commande);
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
        Commande commande = new Commande()
        {
            DateCommande = commandeDTO.DateCommande,
            IdCode = commandeDTO.IdCode,
            IdStatut = commandeDTO.IdStatut,
            IdModeExp = commandeDTO.IdModeExp,
            IdAdresse = commandeDTO.IdAdresse,
            IdBoutique = commandeDTO.IdBoutique,
            IdAdresseFactu = commandeDTO.IdAdresseFactu,
            IdModePayement = commandeDTO.IdModePayement,
            IdClient = commandeDTO.IdClient,
        };
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