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

namespace SAE_G2_Upway_API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class ProduitsController : ControllerBase
{
    private readonly  IDataRepository<Produit> dataRepository;

    public ProduitsController(IDataRepository<Produit> dataRepo)
    {
        dataRepository = dataRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
    {
        return await dataRepository.GetAllAsync();
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<Produit>> GetProduitById(int id)
    {
        var produit = dataRepository.GetByIdAsync(id);
        if (produit == null)
        {
            return NotFound();
        }
        return produit.Result;
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<Produit>> GetProduitByName(string name)
    {
        var produit = await dataRepository.GetByStringAsync(name);
        if (produit == null)
        {
            return NotFound();
        }

        return produit;
    }

    [HttpPut("id/{id}")]
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

    [HttpPost]
    public async Task<ActionResult<Produit>> PostProduit(Produit produit)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await dataRepository.AddAsync(produit);
        return CreatedAtAction("GetProduitById", new { id = produit.Idproduit }, produit);
    }

    [HttpDelete("id/{id}")]
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