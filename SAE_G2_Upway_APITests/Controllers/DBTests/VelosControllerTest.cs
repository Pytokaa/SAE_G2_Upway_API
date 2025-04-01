using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;
using SAE_G2_Upway_API.Migrations;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers.DBTests;

[TestClass]
public class VelosControllerTest
{
    private UpwayDbContext context;
    private IDataRepository<Velo, VeloDtoGet> dataRepository;
    private VelosController controller;

    [TestInitialize]
    public void Init()
    {
        /*var builder = new DbContextOptionsBuilder<UpwayDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
        context = new UpwayDbContext(builder.Options);
        dataRepository = new VeloManager(context);
        controller = new VelosController(dataRepository);*/
    }
}