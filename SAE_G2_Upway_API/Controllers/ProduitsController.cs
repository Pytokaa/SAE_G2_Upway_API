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
}