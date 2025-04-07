using Microsoft.AspNetCore.Mvc;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;


namespace SAE_G2_Upway_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RapportsInspectionController : ControllerBase
{
    private readonly IDataRepository<RapportInspection, RapportInspection> dataRepository;

    public RapportsInspectionController(IDataRepository<RapportInspection, RapportInspection> dataRepo)
    {
        dataRepository = dataRepo;
    }
    
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<RapportInspection>>> GetRapportsInspection()
    {
        return await dataRepository.GetAllAsync();
    }
    
    [HttpGet("id/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<RapportInspection>> GetRapportInspectionByIdVelo(int id)
    {
        var rapport = await dataRepository.GetByIdAsync(id);
        if (rapport == null)
        {
            return NotFound();
        }

        return rapport;
    }
    
    [HttpPut("id/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutRapportInspection(int id, RapportInspection rapport)
    {
        var rapportToUpdate = await dataRepository.GetByIdAsync(id);

        if (rapportToUpdate == null)
        {
            return NotFound();
        }

        dataRepository.UpdateAsync(rapportToUpdate.Value, rapport);
        return NoContent();
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Marque>> PostRapportInspection(RapportInspection rapport )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await dataRepository.AddAsync(rapport);
        return CreatedAtAction("GetRapportInspectionByIdVelo", new { id = rapport.IdRapport }, rapport);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteRapportInspection(int id)
    {
        var rapport = await dataRepository.GetByIdAsync(id);
        if (rapport == null)
        {
            return NotFound();
        }

        

        await dataRepository.DeleteAsync(rapport.Value);
        return NoContent();
    }
}