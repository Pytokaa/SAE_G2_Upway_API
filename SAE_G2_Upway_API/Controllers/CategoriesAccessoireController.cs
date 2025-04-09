using Microsoft.AspNetCore.Mvc;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
namespace SAE_G2_Upway_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesAccessoireController : ControllerBase
{
    private readonly IDataRepository<CategorieAccessoire, CategorieAccessoire> dataRepository;

    public CategoriesAccessoireController(IDataRepository<CategorieAccessoire, CategorieAccessoire> dataRepo)
    {
        dataRepository = dataRepo;
    }
   
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<CategorieAccessoire>>> GetCategoriesAccessoire()
    {
        return await dataRepository.GetAllAsync();
    }
    
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CategorieAccessoire>> GetCategorieAccessoireById(int id)
    {
        var cateAcce = await dataRepository.GetByIdAsync(id);
        if (cateAcce.Value == null)
        {
            return NotFound();
        }

        return cateAcce;
    }
    
    [HttpPut("id/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutCategorieAccessoire(int id, CategorieAccessoire cateAcce)
    {
        var cateAcceToUpdate = await dataRepository.GetByIdAsync(id);

        if (cateAcceToUpdate == null)
        {
            return NotFound();
        }

        dataRepository.UpdateAsync(cateAcceToUpdate.Value, cateAcce);
        return NoContent();
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CategorieAccessoire>> PostCategorieAccessoire(CategorieAccessoire cateAcce)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await dataRepository.AddAsync(cateAcce);
        return CreatedAtAction("GetCategorieAccessoireById", new { id = cateAcce.IdCatA }, cateAcce);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteCategorieAccessoire(int id)
    {
        var cateAcce = await dataRepository.GetByIdAsync(id);
        if (cateAcce == null)
        {
            return NotFound();
        }

        

        await dataRepository.DeleteAsync(cateAcce.Value);
        return NoContent();
    }
}