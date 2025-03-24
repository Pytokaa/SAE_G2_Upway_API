using Microsoft.AspNetCore.Mvc;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesVeloController : ControllerBase
{
    private readonly IDataRepository<CategorieVelo, CategorieVelo> dataRepository;

    public CategoriesVeloController(IDataRepository<CategorieVelo, CategorieVelo> dataRepo)
    {
        dataRepository = dataRepo;
    }
   
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<CategorieVelo>>> GetCategoriesVelo()
    {
        return await dataRepository.GetAllAsync();
    }
    
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CategorieVelo>> GetCategorieVeloById(int id)
    {
        var cateVelo = await dataRepository.GetByIdAsync(id);
        if (cateVelo == null)
        {
            return NotFound();
        }

        return cateVelo;
    }
    
    [HttpPut("id/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutCategorieVelo(int id, CategorieVelo cateVelo)
    {
        var cateVeloToUpdate = await dataRepository.GetByIdAsync(id);

        if (cateVeloToUpdate == null)
        {
            return NotFound();
        }

        dataRepository.UpdateAsync(cateVeloToUpdate.Value, cateVelo);
        return NoContent();
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CategorieVelo>> PostCategorieVelo(CategorieVelo cateVelo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await dataRepository.AddAsync(cateVelo);
        return CreatedAtAction("GetCategorieVeloById", new { id = cateVelo.IdCat }, cateVelo);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteCategorieVelo(int id)
    {
        var cateVelo = await dataRepository.GetByIdAsync(id);
        if (cateVelo == null)
        {
            return NotFound();
        }

        

        await dataRepository.DeleteAsync(cateVelo.Value);
        return NoContent();
    }
}