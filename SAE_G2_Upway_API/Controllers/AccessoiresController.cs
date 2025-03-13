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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accessoire>>> GetAccessoires()
        {
            return dataRepository.GetAll();
        }

        // GET: api/Accessoires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accessoire>> GetAccessoireById(int id)
        {
            var accessoire = dataRepository.GetByIdAsync(id);

            if (accessoire == null)
            {
                return NotFound();
            }

            return accessoire.Result;
        }

        
        
        
        [HttpGet("{nom}")]
        [ActionName("GetByAccessoireName")]
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        [HttpPost]
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessoire(int id)
        {
            var accessoire = dataRepository.GetByIdAsync(id);
            if (accessoire == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(accessoire.Result.Value);
            return NoContent();
        }
        /*
        private bool VeloExists(int id)
        {
            return _context.Velos.Any(e => e.IdVelo == id);
        }
        */
}