using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class AccessoiresControllerTests
    {
        private UpwayDBContext dbContext;
        private AccessoiresController accessoiresController;
        private IDataRepository<Accessoire> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("UpwayDBContext");
            dbContext = new UpwayDBContext(builder.Options);
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
            var accessoiresBase = dbContext.Accessoires.ToList();
            var accessoiresGetAll = accessoiresController.GetAccessoires();
            
            CollectionAssert.AreEquivalent(accessoiresBase, accessoiresGetAll.Result.Value.ToList(), "Get all accessoires ne fonctionne pas correctement");
        }

        [TestMethod()]
        public void GetAccessoireByIdTest_ReturnsOK_AvecMoq()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAccessoireByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutAccessoireTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostAccessoireTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAccessoireTest()
        {
            Assert.Fail();
        }
    }
}