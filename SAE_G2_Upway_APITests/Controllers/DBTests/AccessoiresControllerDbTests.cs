using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers.DBTests;

[TestClass]
public class AccessoiresControllerDbTests
{

    private UpwayDBContext dbContext;
    private AccessoiresController controller;
    private IDataRepository<Accessoire, AccessoireDtoGet> dataRepository;

    [TestInitialize]
    public void Init()
    {
        var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
        dbContext = new UpwayDBContext(builder.Options);
        dataRepository = new AccessoireManager(dbContext);
        controller = new AccessoiresController(dataRepository);
    }

    [TestMethod()]
    public void AccessoiresControllerTest()
    {
        //Assert
        Assert.IsNotNull(controller);
    }

    [TestMethod()]
    public void GetAccessoiresTest_ReturnsOK()
    {
        //Arrange
        var actual_accessoires = controller.GetAccessoires().Result;
        var expected_accessoires = dbContext.AccToDtoGet(dbContext.Accessoires.ToList());
        //Assert
        CollectionAssert.AreEqual(actual_accessoires.Value.ToList(), expected_accessoires,"Les 2 accessoires ne sont pas du egals");
    }

    [TestMethod()]
    public void GetAccessoireByIdTest_ReturnsOK()
    {
        //Act
        var actual_accessoire = controller.GetAccessoireById(1).Result;
        var expected_accessoire = dbContext.Accessoires.FirstOrDefault(x => x.IdAccessoire == 1);
        //Assert
        Assert.AreEqual(actual_accessoire.Value, expected_accessoire, "Les accessoires ne correspondent pas");
    }

    [TestMethod()]
    public void GetAccessoireByIdTest_InvalidId_ReturnsNotFound()
    {
        //Act
        var actual_accessoire = controller.GetAccessoireById(0).Result;
        //Assert
        Assert.IsInstanceOfType(actual_accessoire.Result, typeof(NotFoundResult), "Ce n'est pas d'instance NOTFOUND");
    }
    
    [TestCleanup]
    public void Cleanup() 
    {
        dbContext = null;
        dataRepository = null;
        controller = null;
    }
}