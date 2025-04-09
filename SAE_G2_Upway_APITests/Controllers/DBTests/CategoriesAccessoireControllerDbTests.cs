using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Migrations;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers.DBTests;

[TestClass]
public class CategoriesAccessoireControllerDbTests
{
    private UpwayDBContext? context;
    private IDataRepository<CategorieAccessoire, CategorieAccessoire>? dataRepository;
    private CategoriesAccessoireController controller;

    [TestInitialize]
    public void Init()
    {
        var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
        context = new UpwayDBContext(builder.Options);
        dataRepository = new CategorieAccessoireManager(context);
        controller = new CategoriesAccessoireController(dataRepository);
    }
    
    [TestMethod]
    public void GetAllCategorieAccessoire_Succed()
    {
        var actual_categorie = controller.GetCategoriesAccessoire().Result;
        var expected_categorie = context.CategorieAccessoires.ToList();
        //Assert
        CollectionAssert.AreEqual(actual_categorie.Value.ToList(), expected_categorie, "Les 2 listes de categorie ne sont pas similaire");
    }

    [TestMethod]
    public void GetCategorieAccessoireById_ValidIdPassed_OkReturned()
    {
        var actual_categorie = controller.GetCategorieAccessoireById(1).Result;
        var expected_categorie = context.CategorieAccessoires.FirstOrDefault(x => x.IdCatA == 1);
        //Assert
        Assert.AreEqual(actual_categorie.Value, expected_categorie, "Les 2 categorie accessoires ne correspondent pas");
    }

    [TestMethod]
    public void PutCategorieAccessoireById_InvalidIdPassed_NotFoundReturned()
    {
        var action_result = controller.GetCategorieAccessoireById(0).Result;
        //Assert
        Assert.IsInstanceOfType(action_result.Result, typeof(NotFoundResult), "Le resultat n'esrt pas un NotFopundResult");
    }

    [TestCleanup]
    public void Cleanup()
    {
        context = null;
        controller = null;
        dataRepository = null;
    }
}