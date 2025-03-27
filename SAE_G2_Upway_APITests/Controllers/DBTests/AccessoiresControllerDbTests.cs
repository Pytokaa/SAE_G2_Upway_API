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
        var expected_accessoires = dbContext.Accessoires.ToList();
        // List<AccessoireDtoGet> actual_accessoiresDtoGet = new List<AccessoireDtoGet>();
        // List<AccessoireDtoGet> expected_accessoiresDtoGet = new List<AccessoireDtoGet>();
        // //Act
        // foreach (var item in actual_accessoires.Value)
        // {
        //     AccessoireDtoGet accessoireDtoGet = item;
        //     actual_accessoiresDtoGet.Add(accessoireDtoGet);
        // }
        // foreach (var acc in expected_accessoires) // Maintenant, c'est une liste en mémoire
        // {
        //     expected_accessoiresDtoGet.Add(new AccessoireDtoGet()
        //     {
        //         Nom = acc.Produit.NomProduit,
        //         Prix = acc.Produit.PrixProduit,
        //         Url = acc.Produit.Photo.Url,
        //         Marque = acc.Produit.Marque.NomMarque,
        //         Categorie = acc.CategorieAccessoire.NomCatA,
        //         DateAccessoire = acc.DateAccessoire,
        //     });
        // }
        //Assert
        CollectionAssert.AreEqual(actual_accessoires.Value.ToList(), expected_accessoires, "Les 2 lists ne sont pas du egals");
    }
}