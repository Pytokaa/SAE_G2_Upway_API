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
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;

namespace SAE_G2_Upway_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccessoiresController : ControllerBase
{
    private readonly IDataRepository<Accessoire, AccessoireDtoGet> dataRepository;

    public AccessoiresController(IDataRepository<Accessoire, AccessoireDtoGet> dataRepo)
    {
        dataRepository = dataRepo;
    }

    // GET: api/Accessoires
    /// <summary>
    /// R�cup�re la liste de tous les accessoires.
    /// </summary>
    /// <returns>Une r�ponse HTTP contenant la liste des accessoires.</returns>
    /// <response code="200">La requ�te a r�ussi, et la liste des accessoires est retourn�e.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<AccessoireDtoGet>>> GetAccessoires()
    {
        return await dataRepository.GetAllAsync();
    }

    // GET: api/Accessoires/5
    /// <summary>
    /// R�cup�re un accessoire sp�cifique par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de l'accessoire � r�cup�rer.</param>
    /// <returns>Une r�ponse HTTP contenant l'accessoire correspondant � l'identifiant.</returns>
    /// <response code="200">L'accessoire a �t� trouv� et est retourn�.</response>
    /// <response code="404">Aucun accessoire n'a �t� trouv� avec l'identifiant sp�cifi�.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Accessoire>> GetAccessoireById(int id)
    {
        var accessoire = await dataRepository.GetByIdAsync(id);
        
        
        
        if (accessoire == null)
        {
            return NotFound();
        }

        return accessoire;
    }

    

    // PUT: api/Accessoires/id/{id}
    /// <summary>
    /// Met � jour un accessoire existant par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de l'accessoire � mettre � jour.</param>
    /// <param name="accessoire">Les nouvelles donn�es de l'accessoire.</param>
    /// <returns>Une r�ponse HTTP indiquant le r�sultat de l'op�ration.</returns>
    /// <response code="204">L'accessoire a �t� mis � jour avec succ�s.</response>
    /// <response code="400">Les donn�es fournies sont invalides ou l'identifiant ne correspond pas � celui de l'accessoire.</response>
    /// <response code="404">Aucun accessoire n'a �t� trouv� avec l'identifiant sp�cifi�.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpPut("id/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutAccessoire(int id, AccessoireDTO accessoireDTO)
    {
        var accessoireToUpdate = await dataRepository.GetByIdAsync(id);
        Console.WriteLine(accessoireToUpdate.Value.IdProduit);
        if (accessoireToUpdate == null)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        Accessoire accessoire = new Accessoire()
        {
            IdAccessoire = id,
            IdProduit = accessoireDTO.IdProduit,
            IdCatA = accessoireDTO.IdCatA,
            DateAccessoire = accessoireDTO.DateAccessoire,
            
        };

        
        dataRepository.UpdateAsync(accessoireToUpdate.Value, accessoire);
        return NoContent();
        

        
    }

    // POST: api/Accessoires
    /// <summary>
    /// Ajoute un nouvel accessoire � la base de donn�es.
    /// </summary>
    /// <param name="accessoire">Les donn�es de l'accessoire � ajouter.</param>
    /// <returns>Une r�ponse HTTP contenant l'accessoire cr��.</returns>
    /// <response code="201">L'accessoire a �t� cr�� avec succ�s.</response>
    /// <response code="400">Les donn�es fournies sont invalides ou incompl�tes.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Accessoire>> PostAccessoire(AccessoireDTO accessoireDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Accessoire accessoire = new Accessoire()
        {
            IdProduit = accessoireDTO.IdProduit,
            IdCatA = accessoireDTO.IdCatA,
            DateAccessoire = accessoireDTO.DateAccessoire,
            
        };
        await dataRepository.AddAsync(accessoire);
        return CreatedAtAction("GetAccessoireById", new { id = accessoire.IdAccessoire }, accessoire);
    }

    // DELETE: api/Accessoires/{id}
    /// <summary>
    /// Supprime un accessoire existant par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de l'accessoire � supprimer.</param>
    /// <returns>Une r�ponse HTTP indiquant le r�sultat de l'op�ration.</returns>
    /// <response code="204">L'accessoire a �t� supprim� avec succ�s.</response>
    /// <response code="404">Aucun accessoire n'a �t� trouv� avec l'identifiant sp�cifi�.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteAccessoire(int id)
    {
        var accessoire = await dataRepository.GetByIdAsync(id);
        if (accessoire == null)
        {
            return NotFound();
        }

        int idProduit = accessoire.Value.IdProduit;

        await dataRepository.DeleteAsync(accessoire.Value);
        return NoContent();
    }
}