using Microsoft.AspNetCore.Mvc;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class MarquesController : ControllerBase
{
    private readonly IDataRepository<Marque, Marque> dataRepository;

    public MarquesController(IDataRepository<Marque, Marque> dataRepo)
    {
        dataRepository = dataRepo;
    }
    
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<Marque>>> GetMarques()
    {
        return await dataRepository.GetAllAsync();
    }
    
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Marque>> GetMarqueById(int id)
    {
        var marque = await dataRepository.GetByIdAsync(id);
        if (marque.Value == null)
        {
            return NotFound();
        }

        return marque;
    }


    [HttpPut("id/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutMarque(int id, Marque marque)
    {
        var marqueToUpdate = await dataRepository.GetByIdAsync(id);

        if (marqueToUpdate == null)
        {
            return NotFound();
        }

        dataRepository.UpdateAsync(marqueToUpdate.Value, marque);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Marque>> PostMarque(Marque marque)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await dataRepository.AddAsync(marque);
        return CreatedAtAction("GetMarqueById", new { id = marque.IdMarque }, marque);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteMarque(int id)
    {
        var marque = await dataRepository.GetByIdAsync(id);
        if (marque == null)
        {
            return NotFound();
        }

        

        await dataRepository.DeleteAsync(marque.Value);
        return NoContent();
    }
}