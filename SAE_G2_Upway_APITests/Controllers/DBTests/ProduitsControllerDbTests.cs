using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers;

[TestClass]
public class ProduitsControllerDbTests
{
        private UpwayDBContext dbContext;
        private ProduitsController controller;
        private IDataRepository<Produit, Produit> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
            dbContext = new UpwayDBContext(builder.Options);
            dataRepository = new ProduitManager(dbContext);
            controller = new ProduitsController(dataRepository);
        }

        [TestMethod()]
        public void ProduitsControllerTest()
        {
            //Assert
           Assert.IsNotNull(controller);
        }

        [TestMethod()]
        public void GetProduits_ReturnsAllProduits()
        {
            //Act
            var actual_produits = controller.GetProduits().Result;
            var expected_produits = dbContext.Produits.ToList();
            //Assert
            CollectionAssert.AreEqual(expected_produits, actual_produits.Value.ToList(),"Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetProduitById_ReturnsOk()
        {
            //Act
            var actual_produit = controller.GetProduitById(1).Result;
            var expected_produit = dbContext.Produits.FirstOrDefault();
            //Asssert
            Assert.AreEqual(expected_produit, actual_produit.Value, "Les produits ne correspondent pas");
        }

        [TestMethod]
        public void GetProduitById_InvalidId_ReturnsNotFound()
        {
            //Act
            var actual_produit = controller.GetProduitById(0).Result;
            //Assert
            Assert.IsNull(actual_produit.Value, "Les produits ne correspondent pas");
            Assert.IsInstanceOfType(actual_produit.Result, typeof(NotFoundResult),"Le Resultat n'est pas un notfoundresult");
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            dbContext = null;
            dataRepository = null;
            controller = null;
        }
}