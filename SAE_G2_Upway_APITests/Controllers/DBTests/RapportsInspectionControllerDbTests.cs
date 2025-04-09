using Microsoft.AspNetCore.Mvc;
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

    [TestMethod]
    public void GetAllRapportsInspection_Succeed()
    {
        var actual_rapports = controller.GetRapportsInspection().Result;
        var expected_rapports = context.RapportInspections.ToList();
        //Assert
        CollectionAssert.AreEqual(actual_rapports.Value.ToList(), expected_rapports, "les 2 listes ne sont pas egals");
    }

    [TestMethod]
    public void GetRapportInspectionById_ValidId_Succeed()
    {
        var actual_rapport = controller.GetRapportInspectionByIdVelo(1).Result;
        var expected_rapport = context.RapportInspections.FirstOrDefault(x => x.IdVelo == 1);
        //Assert
        Assert.AreEqual(actual_rapport.Value, expected_rapport, "les 2 rapport ne sont pas identique");
    }

    [TestMethod]
    public void GetRapportInspectionById_InvalidId_Failed()
    {
        var action_result = controller.GetRapportInspectionByIdVelo(0).Result;
        //assert
        Assert.IsInstanceOfType(action_result.Result, typeof(NotFoundResult), "Pas un NotFound");
    }

    [TestCleanup]
    public void Cleanup()
    {
        context = null;
        dataRepository = null;
        controller = null;
    }
}