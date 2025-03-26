using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SAE_G2_Upway_API.Controllers.DTO;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class ProduitsControllerTestsMoq
    {
        private UpwayDBContext dbContext;
        private ProduitsController produitController;
        private IDataRepository<Produit, Produit> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=localhost;port=5432;Database=SAE_G2_Upway; uid=postgres; password=postgres;");
            dbContext = new UpwayDBContext(builder.Options);
            dataRepository = new ProduitManager(dbContext);
            produitController = new ProduitsController(dataRepository);
            
        }

        [TestMethod()]
        public void ProduitsControllerTest()
        {
            var produitsMock = new List<Produit>
            {
                new Produit(1, 1, 1, "Produit A", 100, 10, "Description A"),
                new Produit(2, 2, 2, "Produit B", 200, 20, "Description B")
            };

            // 2. Création du mock du repository
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(produitsMock);

            // 3. Création du contrôleur avec le mock
            var produitController = new ProduitsController(mockRepository.Object);

            // 4. Exécution de la méthode
            var result = produitController.GetProduits().Result;

            // 5. Vérifications
            Assert.IsNotNull(result.Value, "La liste des produits ne doit pas être null");
            Assert.AreEqual(2, result.Value.Count(), "Le nombre de produits est incorrect");
            CollectionAssert.AreEquivalent(produitsMock, result.Value.ToList(), "Les produits ne correspondent pas.");
        }

        [TestMethod]
        public void GetProduits_ReturnsAllProduits()
        {
            var result = produitController.GetProduits().Result;
 
            List<Produit> resultList = new List<Produit>();
 
            foreach (var item in result.Value)
            {
                Produit produit = new Produit(
                    item.Idproduit,
                    item.IdPhoto,
                    item.IdMarque,
                    item.NomProduit,
                    item.PrixProduit,
                    item.StockProduit,
                    item.DescriptionProduit
                );
                resultList.Add(produit);
            }
 
            List<Produit> produitsBase = dbContext.Produits.ToList();
 
            CollectionAssert.AreEqual(produitsBase, resultList, "Get all produits ne fonctionne pas correctement");
         }

        [TestMethod()]
        public void GetProduitByIdTest_ReturnsOK_avecMoq()
        {
            Produit produitTest = new Produit(
                5,
                5,
                5,
                "Vélo de ville Nakamura E-City",
                1300,
                10,
                "Vélo de ville électrique idéal pour les trajets quotidiens."
                );
            
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produitTest);
            
            var produitController = new ProduitsController(mockRepository.Object);
            
            var actionResult = produitController.GetProduitById(5).Result;
            Produit result = new Produit(
                actionResult.Value.Idproduit,
                actionResult.Value.IdPhoto,
                actionResult.Value.IdMarque,
                actionResult.Value.NomProduit,
                actionResult.Value.PrixProduit,
                actionResult.Value.StockProduit,
                actionResult.Value.DescriptionProduit
                );
            
            Assert.IsNotNull(actionResult,"is not null premier ne marche pas");
            Assert.IsNotNull(actionResult.Value, "is not null second ne marche pas");
            Assert.AreEqual(produitTest, result,"Get all produits ne fonctionne pas correctement");
        }

        [TestMethod()]
        public void GetProduitByIdTest_ReturnsNotFound_avecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            
            var produitController = new ProduitsController(mockRepository.Object);
            
            
            var actionResult = produitController.GetProduitById(0).Result;
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult), "la reponse n'est pas de type NotFoundResult");
        }

        [TestMethod()]
        public void PutProduitTest_AvecMoq()
        {
            Produit produitBase = new Produit(
                5,
                5,
                5,
                "Vélo de ville Nakamura E-City",
                1300,
                10,
                "Vélo de ville électrique idéal pour les trajets quotidiens."
            );
            ProduitDTO produitModif = new ProduitDTO();
            produitModif.IdMarque = 5;
            produitModif.IdPhoto = 5;
            produitModif.NomProduit = "Test";
            produitModif.PrixProduit = 1300;
            produitModif.StockProduit = 10;
            produitModif.DescriptionProduit = "Vélo de ville électrique idéal pour les trajets quotidiens.";

            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produitBase);
            var produitController = new ProduitsController(mockRepository.Object);
            
            var actionResult = produitController.PutProduit(5, produitModif).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "la reponse n'est pas de type NoContentResult");
        }
        
        [TestMethod()]
        public void PutProduitTest_InvalidId_ReturnsNotFound_avecMoq()
        {
            ProduitDTO produitModif = new ProduitDTO();
            produitModif.IdMarque = 5;
            produitModif.IdPhoto = 5;
            produitModif.NomProduit = "Vélo de ville Nakamura E-City";
            produitModif.PrixProduit = 1300;
            produitModif.StockProduit = 10;
            produitModif.DescriptionProduit = "Vélo de ville électrique idéal pour les trajets quotidiens.";

            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Produit)null);
            var produitController = new ProduitsController(mockRepository.Object);
            
            var actionResult = produitController.PutProduit(0, produitModif).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult), "la reponse n'est pas de type BadRequestResult");
        }
        
        [TestMethod()]
        public void PutProduitTest_InvalidInput_ReturnsNotFound_avecMoq()
        {
            ProduitDTO produitModif = new ProduitDTO();
            produitModif.IdMarque = 5;
            produitModif.IdPhoto = 5;
            produitModif.NomProduit = null;
            produitModif.PrixProduit = 1300;
            produitModif.StockProduit = 10;
            produitModif.DescriptionProduit = "Vélo de ville électrique idéal pour les trajets quotidiens.";

            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            var produitBase = new Produit(5, 5, 5, "Vélo", 1300, 10, "Description");
            mockRepository.Setup(x => x.GetByIdAsync(5)).ReturnsAsync(produitBase);
            
            var produitController = new ProduitsController(mockRepository.Object);
            
            produitController.ModelState.AddModelError("NomProduit", "Le nom du produit est obligatoire");
            
            var actionResult = produitController.PutProduit(5, produitModif).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult), "la reponse n'est pas de type BadRequestResult");
        }

        [TestMethod()]
        public void PostProduitTest_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            var produitController = new ProduitsController(mockRepository.Object);
            
            ProduitDTO produitTest = new ProduitDTO();
            produitTest.IdMarque = 1;
            produitTest.IdPhoto = 1;
            produitTest.NomProduit = "oui";
            produitTest.PrixProduit = 13;
            produitTest.StockProduit = 10;
            produitTest.DescriptionProduit = "dv";
            
            var actionResult = produitController.PostProduit(new ProduitDTO()).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Produit>), "la reponse n'est pas de type ActionResult<produit>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "la reponse n'est pas de type CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Produit), "la reponse n'est pas de type Produit");
        }

        [TestMethod()]
        public void PostProduitTest_InvalidInput_ReturnsBadRequest_avecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            var produitController = new ProduitsController(mockRepository.Object);
            
            ProduitDTO produitTest = new ProduitDTO();
            produitTest.IdMarque = 1;
            produitTest.IdPhoto = 1;
            produitTest.NomProduit = null;
            produitTest.PrixProduit = 13;
            produitTest.StockProduit = 10;
            produitTest.DescriptionProduit = "dv";
            
            produitController.ModelState.AddModelError("NomProduit", "Le nom du produit est obligatoire");
            
            var actionResult = produitController.PostProduit(new ProduitDTO()).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Produit>), "la reponse n'est pas de type ActionResult<produit>");
            
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult), "la reponse n'est pas de type BadRequestResult");
        }

        [TestMethod()]
        public void DeleteProduitTest_AvecMoq()
        {
            Produit produitBase = new Produit(
                5,
                5,
                5,
                "Vélo de ville Nakamura E-City",
                1300,
                10,
                "Vélo de ville électrique idéal pour les trajets quotidiens."
            );
            
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produitBase);
            var produitController = new ProduitsController(mockRepository.Object);
            
            var actionResult = produitController.DeleteProduit(5).Result;
            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NoContentResult), "la reponse n'est pas de type NoContentResult");
        }
        
        [TestMethod()]
        public void DeleteProduitTest_InvalidId_ReturnsNotFound_avecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Produit)null);
            var produitController = new ProduitsController(mockRepository.Object);
            
            var actionResult = produitController.DeleteProduit(0).Result;
            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult), "la reponse n'est pas de type NotFoundResult");
        }

        [TestCleanup]
        public void Cleanup()
        {
            dbContext = null;
            dataRepository = null;
            produitController = null;
        }
    }
}