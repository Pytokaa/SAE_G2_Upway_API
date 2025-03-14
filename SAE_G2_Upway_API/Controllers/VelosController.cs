using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VelosController : ControllerBase
    {
        private readonly IDataRepository<Velo>  dataRepository;

        public VelosController(IDataRepository<Velo> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Velos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Velo>>> GetVelos()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Velos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Velo>> GetVeloById(int id)
        {
            var velo = dataRepository.GetByIdAsync(id);

            if (velo == null)
            {
                return NotFound();
            }

            return velo.Result;
        }

        
        
        
        [HttpGet("{nom}")]
        [ActionName("GetVeloByName")]
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVelo(int id, Velo velo)
        {
            if (id != velo.IdVelo)
            {
                return BadRequest();
            }

           var veloToUpdate = dataRepository.GetByIdAsync(id);

           if (veloToUpdate == null)
           {
               return NotFound();
           }
           else
           {
               dataRepository.UpdateAsync(veloToUpdate.Result.Value, velo);
               return NoContent();
           }

            return NoContent();
        }

        // POST: api/Velos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Velo>> PostVelo(Velo velo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(velo);
            return CreatedAtAction("GetVeloById", new { id = velo.IdVelo }, velo);
        }

        // DELETE: api/Velos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVelo(int id)
        {
            var velo = dataRepository.GetByIdAsync(id);
            if (velo == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(velo.Result.Value);
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
