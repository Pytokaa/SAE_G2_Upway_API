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
    private AccessoiresController accessoiresController;
    private IDataRepository<Accessoire, AccessoireDtoGet> dataRepository;

    [TestInitialize]
    public void Init()
    {
        var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
        dbContext = new UpwayDBContext(builder.Options);
        dataRepository = new AccessoireManager(dbContext);
        accessoiresController = new AccessoiresController(dataRepository);
    }

    [TestMethod()]
    public void AccessoiresControllerTest()
    {
        var accessoiresController = new AccessoiresController(dataRepository);
        Assert.IsNotNull(accessoiresController);
        Assert.IsInstanceOfType(accessoiresController, typeof(AccessoiresController));
    }

    [TestMethod()]
    public void GetAccessoiresTest_ReturnsOK()
    {
        var result = accessoiresController.GetAccessoires().Result;

        List<AccessoireDtoGet> accessoiresDto = new List<AccessoireDtoGet>();

        foreach (var item in result.Value)
        {
            AccessoireDtoGet accessoireDtoGet = item;
            accessoiresDto.Add(accessoireDtoGet);
        }

        List<Accessoire> accessoiresBase = dbContext.Accessoires.ToList();

        List<AccessoireDtoGet> lesAccessoires = new List<AccessoireDtoGet>();
        foreach (var acc in accessoiresBase) // Maintenant, c'est une liste en mémoire
        {
            lesAccessoires.Add(new AccessoireDtoGet()
            {
                Nom = acc.Produit.NomProduit,
                Prix = acc.Produit.PrixProduit,
                Url = acc.Produit.Photo.Url,
                Marque = acc.Produit.Marque.NomMarque,
                Categorie = acc.CategorieAccessoire.NomCatA,
                DateAccessoire = acc.DateAccessoire,
            });
        }
        CollectionAssert.AreEqual(lesAccessoires, accessoiresDto, "Les 2 lists ne sont pas du egals");
    }
}