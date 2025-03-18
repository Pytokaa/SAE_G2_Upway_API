using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccessoiresController : ControllerBase
{
    private readonly IDataRepository<Accessoire> dataRepository;

    public AccessoiresController(IDataRepository<Accessoire> dataRepo)
    {
        dataRepository = dataRepo;
    }

    // GET: api/Accessoires
    /// <summary>
    /// Récupère la liste de tous les accessoires.
    /// </summary>
    /// <returns>Une réponse HTTP contenant la liste des accessoires.</returns>
    /// <response code="200">La requête a réussi, et la liste des accessoires est retournée.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<Accessoire>>> GetAccessoires()
    {
        return await dataRepository.GetAllAsync();
    }

    // GET: api/Accessoires/5
    /// <summary>
    /// Récupère un accessoire spécifique par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de l'accessoire à récupérer.</param>
    /// <returns>Une réponse HTTP contenant l'accessoire correspondant à l'identifiant.</returns>
    /// <response code="200">L'accessoire a été trouvé et est retourné.</response>
    /// <response code="404">Aucun accessoire n'a été trouvé avec l'identifiant spécifié.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Accessoire>> GetAccessoireById(int id)
    {
        var accessoire = dataRepository.GetByIdAsync(id);

        if (accessoire == null)
        {
            return NotFound();
        }

        return accessoire.Result;
    }

    // GET: api/Accessoires/name/{nom}
    /// <summary>
    /// Récupère un accessoire spécifique par son nom.
    /// </summary>
    /// <param name="nom">Le nom de l'accessoire à récupérer.</param>
    /// <returns>Une réponse HTTP contenant l'accessoire correspondant au nom.</returns>
    /// <response code="200">L'accessoire a été trouvé et est retourné.</response>
    /// <response code="404">Aucun accessoire n'a été trouvé avec le nom spécifié.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpGet("name/{nom}")]
    [ActionName("GetByAccessoireName")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Accessoire>> GetAccessoireByName(string nom)
    {
        var accessoire = await dataRepository.GetByStringAsync(nom);
        if (accessoire == null)
        {
            return NotFound();
        }

        return accessoire;
    }

    // PUT: api/Accessoires/id/{id}
    /// <summary>
    /// Met à jour un accessoire existant par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de l'accessoire à mettre à jour.</param>
    /// <param name="accessoire">Les nouvelles données de l'accessoire.</param>
    /// <returns>Une réponse HTTP indiquant le résultat de l'opération.</returns>
    /// <response code="204">L'accessoire a été mis à jour avec succès.</response>
    /// <response code="400">Les données fournies sont invalides ou l'identifiant ne correspond pas à celui de l'accessoire.</response>
    /// <response code="404">Aucun accessoire n'a été trouvé avec l'identifiant spécifié.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpPut("id/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutAccessoire(int id, Accessoire accessoire)
    {
        if (id != accessoire.IdAccessoire)
        {
            return BadRequest();
        }

        var accessoireToUpdate = dataRepository.GetByIdAsync(id);

        if (accessoireToUpdate == null)
        {
            return NotFound();
        }
        else
        {
            dataRepository.UpdateAsync(accessoireToUpdate.Result.Value, accessoire);
            return NoContent();
        }

        return NoContent();
    }

    // POST: api/Accessoires
    /// <summary>
    /// Ajoute un nouvel accessoire à la base de données.
    /// </summary>
    /// <param name="accessoire">Les données de l'accessoire à ajouter.</param>
    /// <returns>Une réponse HTTP contenant l'accessoire créé.</returns>
    /// <response code="201">L'accessoire a été créé avec succès.</response>
    /// <response code="400">Les données fournies sont invalides ou incomplètes.</response>
    /// <response code="500">Une erreur interne du serveur s'est produite.</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Accessoire>> PostAccessoire(Accessoire accessoire)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await dataRepository.AddAsync(accessoire);
        return CreatedAtAction("GetAccessoireById", new { id = accessoire.IdAccessoire }, accessoire);
    }

    // DELETE: api/Accessoires/{id}
    /// <summary>
    /// Supprime un accessoire existant par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de l'accessoire à supprimer.</param>
    /// <returns>Une réponse HTTP indiquant le résultat de l'opération.</returns>
    /// <response code="204">L'accessoire a été supprimé avec succès.</response>
    /// <response code="404">Aucun accessoire n'a été trouvé avec l'identifiant spécifié.</response>
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