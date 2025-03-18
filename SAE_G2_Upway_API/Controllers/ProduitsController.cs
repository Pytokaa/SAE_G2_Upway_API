using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IDataRepository<Produit> dataRepository;

        public ProduitsController(IDataRepository<Produit> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Produits
        /// <summary>
        /// Récupère la liste de tous les produits.
        /// </summary>
        /// <returns>Une réponse HTTP contenant la liste des produits.</returns>
        /// <response code="200">La requête a réussi, et la liste des produits est retournée.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Produits/id/{id}
        /// <summary>
        /// Récupère un produit spécifique par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du produit à récupérer.</param>
        /// <returns>Une réponse HTTP contenant le produit correspondant à l'identifiant.</returns>
        /// <response code="200">Le produit a été trouvé et est retourné.</response>
        /// <response code="404">Aucun produit n'a été trouvé avec l'identifiant spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpGet("id/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produit>> GetProduitById(int id)
        {
            var produit = dataRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return produit.Result;
        }

        // GET: api/Produits/name/{name}
        /// <summary>
        /// Récupère un produit spécifique par son nom.
        /// </summary>
        /// <param name="name">Le nom du produit à récupérer.</param>
        /// <returns>Une réponse HTTP contenant le produit correspondant au nom.</returns>
        /// <response code="200">Le produit a été trouvé et est retourné.</response>
        /// <response code="404">Aucun produit n'a été trouvé avec le nom spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpGet("name/{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produit>> GetProduitByName(string name)
        {
            var produit = await dataRepository.GetByStringAsync(name);
            if (produit == null)
            {
                return NotFound();
            }
            return produit;
        }

        // PUT: api/Produits/id/{id}
        /// <summary>
        /// Met à jour un produit existant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du produit à mettre à jour.</param>
        /// <param name="produit">Les nouvelles données du produit.</param>
        /// <returns>Une réponse HTTP indiquant le résultat de l'opération.</returns>
        /// <response code="204">Le produit a été mis à jour avec succès.</response>
        /// <response code="400">Les données fournies sont invalides ou l'identifiant ne correspond pas à celui du produit.</response>
        /// <response code="404">Aucun produit n'a été trouvé avec l'identifiant spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpPut("id/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.Idproduit)
            {
                return BadRequest();
            }

            var produitToUpdate = dataRepository.GetByIdAsync(id);
            if (produitToUpdate == null)
            {
                return NotFound();
            }

            dataRepository.UpdateAsync(produitToUpdate.Result.Value, produit);
            return NoContent();
        }

        // POST: api/Produits
        /// <summary>
        /// Ajoute un nouveau produit à la base de données.
        /// </summary>
        /// <param name="produit">Les données du produit à ajouter.</param>
        /// <returns>Une réponse HTTP contenant le produit créé.</returns>
        /// <response code="201">Le produit a été créé avec succès.</response>
        /// <response code="400">Les données fournies sont invalides ou incomplètes.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(produit);
            return CreatedAtAction("GetProduitById", new { id = produit.Idproduit }, produit);
        }

        // DELETE: api/Produits/id/{id}
        /// <summary>
        /// Supprime un produit existant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du produit à supprimer.</param>
        /// <returns>Une réponse HTTP indiquant le résultat de l'opération.</returns>
        /// <response code="204">Le produit a été supprimé avec succès.</response>
        /// <response code="404">Aucun produit n'a été trouvé avec l'identifiant spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpDelete("id/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produit>> DeleteProduit(int id)
        {
            var produit = await dataRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(produit.Value);
            return NoContent();
        }
    }
}
