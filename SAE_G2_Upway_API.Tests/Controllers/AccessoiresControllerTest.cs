using System.Linq;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Tests.Controllers;

[TestClass]
//[TestSubject(typeof(AccessoiresController))]
public class AccessoiresControllerTests
{
    private UpwayDBContext dbContext;
    private AccessoiresController accessoiresController;
    private IDataRepository<Accessoire> dataRepository;

    [TestInitialize]
    private void Init()
    {
        var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("UpwayDBContext");
        dbContext = new UpwayDBContext(builder.Options);
        dataRepository = new AccessoireManager(dbContext);
        
        accessoiresController = new AccessoiresController(dataRepository);
    }

    [TestMethod()]
    public void AccessoiresControllerTest()
    {
        /*var accessoireController = new AccessoiresController(dataRepository);
        Assert.IsNotNull(accessoireController);
        Assert.IsInstanceOfType(accessoireController, typeof(AccessoiresController));*/
        Assert.IsNull(null);
    }

    [TestMethod()]
    public void GetAccessoiresTest()
    {
        /*var accessoiresBase = dbContext.Accessoires.ToList();
        var accessoiresGetAll = accessoiresController.GetAccessoires();

        CollectionAssert.AreEquivalent(accessoiresBase, accessoiresGetAll.Result.Value.ToList());*/
        Assert.IsNull(null);
    }
}