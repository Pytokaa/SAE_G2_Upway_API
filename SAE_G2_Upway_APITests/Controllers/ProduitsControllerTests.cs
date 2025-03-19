using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class ProduitsControllerTests
    {
        private UpwayDBContext dbContext;
        private ProduitsController produitController;
        private IDataRepository<Produit> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("UpwayDBContext");
            dbContext = new UpwayDBContext(builder.Options);
            dataRepository = new ProduitManager(dbContext);
            produitController = new ProduitsController(dataRepository);
        }
        
        [TestMethod()]
        public void ProduitsControllerTest()
        {
            var produitsController = new ProduitsController(dataRepository);
            Assert.IsNotNull(produitsController);
            Assert.IsInstanceOfType(produitsController, typeof(ProduitsController));
        }

        [TestMethod]
        public void GetProduits_ReturnsAllProduits()
        {
            var result = produitController.GetProduits().Result;
            
            List<Produit> resultList = [];

            foreach (var item in result.Value)
            {
                Produit produit = new Produit(
                    item.Idproduit,
                    item.IdPhoto,
                    item.IdMarque,
                    item.NomProduit,
                    item.PrixProduit,
                    item.StockProduit,
                    item.DescriptionProduit,
                    item.DansLesFavoris,
                    item.APhotos
                    );
                resultList.Add(produit);
            }
            
            List<Produit> produitsBase = dbContext.Produits.ToList();
            
            CollectionAssert.AreEquivalent(produitsBase, resultList, "Get all produits ne fonctionne pas correctement");
        }

        [TestMethod()]
        public void GetProduitByIdTest_ReturnsOK_avecMoq()
        {
            Produit produitTest = new Produit(
                5,
                5,
                5,
                "Casque Abus Viantor",
                30,
                5,
                "description",
                new List<Est_En_Favoris>(),
                new List<A_Pour_Photo>()
                );
            
            var mockRepository = new Mock<IDataRepository<Produit>>();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produitTest);
            
            var produitController = new ProduitsController(mockRepository.Object);
            
            var actionResult = produitController.GetProduitById(5).Result;
            Produit result = actionResult.Value as Produit;
            
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Result);
            Assert.AreEqual(produitTest, result,"Get all produits ne fonctionne pas correctement");
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