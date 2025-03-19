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

namespace SAE_G2_Upway_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VelosController : ControllerBase
    {
        private readonly IDataRepository<Velo> dataRepository;

        public VelosController(IDataRepository<Velo> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Velos
        /// <summary>
        /// Récupère la liste de tous les vélos.
        /// </summary>
        /// <returns>Une réponse HTTP contenant la liste des vélos.</returns>
        /// <response code="200">La requête a réussi, et la liste des vélos est retournée.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Velo>>> GetVelos()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Velos/5
        /// <summary>
        /// Récupère un vélo spécifique par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du vélo à récupérer.</param>
        /// <returns>Une réponse HTTP contenant le vélo correspondant à l'identifiant.</returns>
        /// <response code="200">Le vélo a été trouvé et est retourné.</response>
        /// <response code="404">Aucun vélo n'a été trouvé avec l'identifiant spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpGet("id/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Velo>> GetVeloById(int id)
        {
            var velo = dataRepository.GetByIdAsync(id);

            if (velo == null)
            {
                return NotFound();
            }

            return velo.Result;
        }

        // GET: api/Velos/name/{nom}
        /// <summary>
        /// Récupère un vélo spécifique par son nom.
        /// </summary>
        /// <param name="nom">Le nom du vélo à récupérer.</param>
        /// <returns>Une réponse HTTP contenant le vélo correspondant au nom.</returns>
        /// <response code="200">Le vélo a été trouvé et est retourné.</response>
        /// <response code="404">Aucun vélo n'a été trouvé avec le nom spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpGet("name/{nom}")]
        [ActionName("GetVeloByName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Velo>> GetVeloByName(string nom)
        {
            var velo = await dataRepository.GetByStringAsync(nom);
            if (velo == null)
            {
                return NotFound();
            }

            return velo;
        }

        // PUT: api/Velos/5
        /// <summary>
        /// Met à jour un vélo existant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du vélo à mettre à jour.</param>
        /// <param name="velo">Les nouvelles données du vélo.</param>
        /// <returns>Une réponse HTTP indiquant le résultat de l'opération.</returns>
        /// <response code="204">Le vélo a été mis à jour avec succès.</response>
        /// <response code="400">Les données fournies sont invalides ou l'identifiant ne correspond pas à celui du vélo.</response>
        /// <response code="404">Aucun vélo n'a été trouvé avec l'identifiant spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutVelo(int id, VeloDTO veloDTO)
        {
            Velo velo = new Velo()
            {
                IdVelo = id,
                IdProduit = veloDTO.IdProduit,
                IdTailleMin = veloDTO.IdTailleMin,
                IdTailleMax = veloDTO.IdTailleMax,
                IdModele = veloDTO.IdModele,
                IdCat = veloDTO.IdCat,
                IdEtat = veloDTO.IdEtat,
                Nbkms = veloDTO.Nbkms,
                Prixneuf = veloDTO.PrixNeuf,
                Poids = veloDTO.Poids,
                Typecadre = veloDTO.TypeCadre,
                Annee = veloDTO.Annee,
                BestSeller = veloDTO.BestSeller,
                NbVente = veloDTO.NbVente,
                QualiteVelo = veloDTO.QualiteVelo

            };

            var veloToUpdate = dataRepository.GetByIdAsync(id);

            if (veloToUpdate == null)
            {
                return NotFound();
            }
            dataRepository.UpdateAsync(veloToUpdate.Result.Value, velo);
            return NoContent();
            

            
        }

        // POST: api/Velos
        /// <summary>
        /// Ajoute un nouveau vélo à la base de données.
        /// </summary>
        /// <param name="velo">Les données du vélo à ajouter.</param>
        /// <returns>Une réponse HTTP contenant le vélo créé.</returns>
        /// <response code="201">Le vélo a été créé avec succès.</response>
        /// <response code="400">Les données fournies sont invalides ou incomplètes.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Velo>> PostVelo(VeloDTO veloDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            Velo velo = new Velo()
            {
                IdProduit = veloDTO.IdProduit,
                IdTailleMin = veloDTO.IdTailleMin,
                IdTailleMax = veloDTO.IdTailleMax,
                IdModele = veloDTO.IdModele,
                IdCat = veloDTO.IdCat,
                IdEtat = veloDTO.IdEtat,
                Nbkms = veloDTO.Nbkms,
                Prixneuf = veloDTO.PrixNeuf,
                Poids = veloDTO.Poids,
                Typecadre = veloDTO.TypeCadre,
                Annee = veloDTO.Annee,
                BestSeller = veloDTO.BestSeller,
                NbVente = veloDTO.NbVente,
                QualiteVelo = veloDTO.QualiteVelo
            };
            
            
            await dataRepository.AddAsync(velo);
            return CreatedAtAction("GetVeloById", new { id = velo.IdVelo }, velo);
        }

        // DELETE: api/Velos/5
        /// <summary>
        /// Supprime un vélo existant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du vélo à supprimer.</param>
        /// <returns>Une réponse HTTP indiquant le résultat de l'opération.</returns>
        /// <response code="204">Le vélo a été supprimé avec succès.</response>
        /// <response code="404">Aucun vélo n'a été trouvé avec l'identifiant spécifié.</response>
        /// <response code="500">Une erreur interne du serveur s'est produite.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteVelo(int id)
        {
            var velo = await dataRepository.GetByIdAsync(id);
            if (velo == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(velo.Value);
            return NoContent();
        }

        /*
        private bool VeloExists(int id)
        {
        
            return _context.Velos.Any(e => e.IdVelo == id);
        }
        */
    }
}