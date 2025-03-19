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
using SAE_G2_Upway_API.Controllers.DTO;


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
        /// R�cup�re la liste de tous les produits.
        /// </summary>
        /// <returns>Une r�ponse HTTP contenant la liste des produits.</returns>
        /// <response code="200">La requ�te a r�ussi, et la liste des produits est retourn�e.</response>
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
        /// R�cup�re un produit sp�cifique par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du produit � r�cup�rer.</param>
        /// <returns>Une r�ponse HTTP contenant le produit correspondant � l'identifiant.</returns>
        /// <response code="200">Le produit a �t� trouv� et est retourn�.</response>
        /// <response code="404">Aucun produit n'a �t� trouv� avec l'identifiant sp�cifi�.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpGet("id/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produit>> GetProduitById(int id)
        {
            var produit = await dataRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return produit;
        }

        // GET: api/Produits/name/{name}
        /// <summary>
        /// R�cup�re un produit sp�cifique par son nom.
        /// </summary>
        /// <param name="name">Le nom du produit � r�cup�rer.</param>
        /// <returns>Une r�ponse HTTP contenant le produit correspondant au nom.</returns>
        /// <response code="200">Le produit a �t� trouv� et est retourn�.</response>
        /// <response code="404">Aucun produit n'a �t� trouv� avec le nom sp�cifi�.</response>
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
        /// Met � jour un produit existant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du produit � mettre � jour.</param>
        /// <param name="produit">Les nouvelles donn�es du produit.</param>
        /// <returns>Une r�ponse HTTP indiquant le r�sultat de l'op�ration.</returns>
        /// <response code="204">Le produit a �t� mis � jour avec succ�s.</response>
        /// <response code="400">Les donn�es fournies sont invalides ou l'identifiant ne correspond pas � celui du produit.</response>
        /// <response code="404">Aucun produit n'a �t� trouv� avec l'identifiant sp�cifi�.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpPut("id/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutProduit(int id, ProduitDTO produitDto)
        {

            Produit produit = new Produit()
            {
                Idproduit = id,
                IdMarque = produitDto.IdMarque,
                IdPhoto = produitDto.IdPhoto,
                NomProduit = produitDto.NomProduit,
                PrixProduit = produitDto.PrixProduit,
                StockProduit = produitDto.StockProduit,
                DescriptionProduit = produitDto.DescriptionProduit,
            };
            
            var produitToUpdate = await dataRepository.GetByIdAsync(id);
            if (produitToUpdate == null)
            {
                return NotFound();
            }

            dataRepository.UpdateAsync(produitToUpdate.Value, produit);
            return NoContent();
        }

        // POST: api/Produits
        /// <summary>
        /// Ajoute un nouveau produit � la base de donn�es.
        /// </summary>
        /// <param name="produit">Les donn�es du produit � ajouter.</param>
        /// <returns>Une r�ponse HTTP contenant le produit cr��.</returns>
        /// <response code="201">Le produit a �t� cr�� avec succ�s.</response>
        /// <response code="400">Les donn�es fournies sont invalides ou incompl�tes.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produit>> PostProduit(ProduitDTO produitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Produit produit = new Produit()
            {
                IdMarque = produitDto.IdMarque,
                IdPhoto = produitDto.IdPhoto,
                NomProduit = produitDto.NomProduit,
                PrixProduit = produitDto.PrixProduit,
                DescriptionProduit = produitDto.DescriptionProduit,
            };
            await dataRepository.AddAsync(produit);
            return CreatedAtAction("GetProduitById", new { id = produit.Idproduit }, produit);
        }

        // DELETE: api/Produits/id/{id}
        /// <summary>
        /// Supprime un produit existant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du produit � supprimer.</param>
        /// <returns>Une r�ponse HTTP indiquant le r�sultat de l'op�ration.</returns>
        /// <response code="204">Le produit a �t� supprim� avec succ�s.</response>
        /// <response code="404">Aucun produit n'a �t� trouv� avec l'identifiant sp�cifi�.</response>
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
