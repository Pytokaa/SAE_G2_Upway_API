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
    private readonly IDataRepository<Accessoire>  dataRepository;

        public AccessoiresController(IDataRepository<Accessoire> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Accessoires
        /// <summary>
        /// Avoir la liste de tous les accessoires
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Http response</returns>
        /// <response code=200>L'api renvoie tous</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Accessoire>>> GetAccessoires()
        {
            return await dataRepository.GetAllAsync();
        }
        
        // GET: api/Accessoires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Recuperer un accessoire a partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accessoire"></param>
        /// <returns>Http response</returns>
        /// <response code=200>L'id de l'accessoire existe</response>
        /// <response code=404>L'id de l'accessoire n'existe pas</response>
        [HttpGet("id/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Accessoire>> GetAccessoireById(int id)
        {
            var accessoire = dataRepository.GetByIdAsync(id);

            if (accessoire == null)
            {
                return NotFound();
            }

            return accessoire.Result;
        }

        /// <summary>
        /// Recuperer un accessoire a partir de son  nom
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="accessoire"></param>
        /// <returns>Http response</returns>
        /// <response code=200>Le nom de l'accessoire existe</response>
        /// <response code=404>Le nom de l'accessoire n'existe pas</response>
        [HttpGet("name/{nom}")]
        [ActionName("GetByAccessoireName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Accessoire>> GetAccessoireByName(string nom)
        {
            var accessoire = await dataRepository.GetByStringAsync(nom);
            if (accessoire == null)
            {
                return NotFound();
            }

            return accessoire;
        }
        
        
        
        
        // PUT: api/Velos/5
        
        /// <summary>
        /// Modifier un accessoire a partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accessoire"></param>
        /// <returns>Http response</returns>
        /// <response code=200>L'id de l'accessoire existe</response>
        /// <response code=404>L'id de l'accessoire n'existe pas</response>
        /// <response code=400>Il y a un element null ou interdit dans le changement</response>
        [HttpPut("id/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
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

        // POST: api/Velos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        /// <summary>
        /// Poster un nouvel accessoire dans la base de donnees
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accessoire"></param>
        /// <returns>Http response</returns>
        /// <response code=201>L'ajout a bien ete effectue</response>
        /// <response code=400>L'ajout de l'accessoire a echoue</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Accessoire>> PostAccessoire(Accessoire accessoire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(accessoire);
            return CreatedAtAction("GetAccessoireById", new { id = accessoire.IdAccessoire },accessoire);
        }

        // DELETE: api/Velos/5
        /// <summary>
        /// Suppromer un accessoire a partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accessoire"></param>
        /// <returns>Http response</returns>
        /// <response code=204>L'accessoire a ete supprimer avec succes</response>
        /// <response code=404>La supression de l'accessoire a echoue</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
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
        /*
        private bool VeloExists(int id)
        {
            return _context.Velos.Any(e => e.IdVelo == id);
        }
        */
}