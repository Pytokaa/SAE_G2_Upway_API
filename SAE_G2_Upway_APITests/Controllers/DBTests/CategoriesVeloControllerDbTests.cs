using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers.DBTests;

[TestClass]
public class CategoriesVeloControllerDbTests
{

    private UpwayDBContext? context;
    private IDataRepository<CategorieVelo, CategorieVelo>? dataRepository;
    private CategoriesVeloController? controller;

    [TestInitialize]
    public void Init()
    {
        var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
        context = new UpwayDBContext(builder.Options);
        dataRepository = new CategorieVeloManager(context);
        controller = new CategoriesVeloController(dataRepository);
    }

    [TestMethod]
    public void GetAllCategoriesVelo_Succeed()
    {
        //Act
        var actual_catergoriev = controller.GetCategoriesVelo().Result;
        var expected_catergoriev = context.CategorieVelos.ToList();
        //Assert
        CollectionAssert.AreEqual(actual_catergoriev.Value.ToList(), expected_catergoriev.ToList(),"Les 2 listes ne sont pas egales");
    }

    [TestMethod]
    public void GetCategorieVeloById_ValidIdPassed_Succeed()
    {
        var actual_categoriev = controller.GetCategorieVeloById(1).Result;
        var expected_categorievelo = context.CategorieVelos.FirstOrDefault(x => x.IdCat == 1);
        //Assert
        Assert.AreEqual(actual_categoriev.Value, expected_categorievelo, "Les 2 categories ne sont pas egals");
    }

    [TestMethod]
    public void GetCategorieVeloById_InvalidIdPassed_Fail()
    {
        var action_result = controller.GetCategorieVeloById(0).Result;
        //Assert
        Assert.IsInstanceOfType(action_result.Result, typeof(NotFoundResult), "Le resultat n'est pas NOT Found Result");
    }

    [TestCleanup]
    public void Cleanup()
    {
        context = null;
        dataRepository = null;
        controller = null;
    }
}