using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers.DBTests;

[TestClass]
public class RapportsInspectionControllerDbTests
{
    private UpwayDBContext context;
    private IDataRepository<RapportInspection,RapportInspection>? dataRepository;
    private RapportsInspectionController? controller;

    [TestInitialize]
    public void Init()
    {
        var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
        context = new UpwayDBContext(builder.Options);
        dataRepository = new RapportInspectionManager(context);
        controller = new RapportsInspectionController(dataRepository);
    }
    
    
    
    
}