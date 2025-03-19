using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class ProduitsControllerTests
    {
        private UpwayDBContext dbContext;
        private ProduitsController produitsController;
        private IDataRepository<Produit> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("UpwayDBContext");
            dbContext = new UpwayDBContext(builder.Options);
            produitsController = new ProduitsController(dataRepository);

        }
        
        [TestMethod()]
        public void ProduitsControllerTest()
        {
            var produitsController = new ProduitsController(dataRepository);
            Assert.IsNotNull(produitsController);
            Assert.IsInstanceOfType(produitsController, typeof(ProduitsController));
        }

        [TestMethod()]
        public void GetProduitsTest_ReturnsOK()
        {
            produitsController = new ProduitsController(dataRepository);

            var produitsBase = dbContext.Produits.ToList();
            var produitsGetAll = produitsController.GetProduits();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("J'adore la bite");
            Console.WriteLine(produitsGetAll.Result.Value.ToList());
            Console.WriteLine("-----------------------------------------");
            CollectionAssert.AreEquivalent(produitsBase, produitsGetAll.Result.Value.ToList(), "Get all produits ne fonctionne pas correctement");
        }

        [TestMethod()]
        public void GetProduitByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetProduitByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutProduitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostProduitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteProduitTest()
        {
            Assert.Fail();
        }
    }
}