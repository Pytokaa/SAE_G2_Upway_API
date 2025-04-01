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

namespace SAE_G2_Upway_APITests.Controllers.Moq
{
    [TestClass()]
    public class ProduitsControllerTestsMoq
    {
        private ProduitsController? produitController;
        private Mock<IDataRepository<Produit, Produit>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Produit, Produit>>();
            produitController = new ProduitsController(mockRepository.Object);
            
        }

        [TestMethod]
        public void GetProduits_ReturnsAllProduits_AvecMoq()
        {
            //Arrange
            List<Produit> produits = new List<Produit>([
                new Produit(1,1,1,"Vélo tout terrain Moustache Samedi 27",2500,5,"VTT Moustache avec suspension intégrale pour le tout-terrain."),
                new Produit(2,2,2,"Vélo de route Cube Agree C:62",2000,8,"Vélo de route ultra-léger en carbone pour la performance."),
                new Produit(3,3,3,"Vélo cargo Giant Expédition",3200,3,"Vélo cargo solide pour transporter des charges lourdes."),
            ]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(produits);
            //Act
            var actual_produits = produitController.GetProduits().Result;
            //Assert
            CollectionAssert.AreEqual(actual_produits.Value.ToList(), produits, "Get all produits ne fonctionne pas correctement");
         }

        [TestMethod()]
        public void GetProduitByIdTest_ReturnsOK_avecMoq()
        {
            //Arrange
            Produit produit = new Produit(5,5,5,"Vélo de ville Nakamura E-City",1300,10,"Vélo de ville électrique idéal pour les trajets quotidiens.");
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produit);
            //Act
            var actionResult = produitController.GetProduitById(5).Result;
            //Assert
            Assert.IsNotNull(actionResult,"is not null premier ne marche pas");
            Assert.IsNotNull(actionResult.Value, "is not null second ne marche pas");
            Assert.AreEqual(produit, actionResult.Value,"Get all produits ne fonctionne pas correctement");
        }

        [TestMethod()]
        public void GetProduitByIdTest_ReturnsNotFound_avecMoq()
        {
            //Arrange
            Produit produit = null;
            ActionResult<Produit> actionResult = new ActionResult<Produit>(produit);
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(actionResult);
            //Act
            var actual_produit = produitController.GetProduitById(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_produit.Result, typeof(NotFoundResult), "la reponse n'est pas de type NotFoundResult");
        }

        [TestMethod()]
        public void PutProduitTest_AvecMoq()
        {
            //Arrange
            Produit produitBase = new Produit(5,5,5,"Vélo de ville Nakamura E-City",1300,10,"Vélo de ville électrique idéal pour les trajets quotidiens.");
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produitBase);
            ProduitDTO produitModif = new ProduitDTO(5,3,"Vélo de ville Nakamura E-City",1300,10,"Vélo de ville électrique idéal pour les trajets quotidiens.");
            //Act
            var actionResult = produitController.PutProduit(5, produitModif).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "la reponse n'est pas de type NoContentResult");
        }
        
        [TestMethod()]
        public void PutProduitTest_InvalidId_ReturnsNotFound_avecMoq()
        {
            //Arrange
            ProduitDTO produitModif = new ProduitDTO(5,5,"Vélo de ville Nakamura E-City",1300,10,"Vélo de ville électrique idéal pour les trajets quotidiens.");
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Produit)null);
            //Act
            var actionResult = produitController.PutProduit(0, produitModif).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult), "la reponse n'est pas de type BadRequestResult");
        }
        
        [TestMethod()]
        public void PutProduitTest_InvalidInput_ReturnsNotFound_avecMoq()
        {
            //Arranges
            Produit produit = new Produit();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produit);
            ProduitDTO produitDto = new ProduitDTO();
            produitController.ModelState.AddModelError("NomProduit", "Le nom du produit est obligatoire");
            //Act
            var actionResult = produitController.PutProduit(5, produitDto).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult), "la reponse n'est pas de type BadRequestResult");
        }

        [TestMethod()]
        public void PostProduitTest_AvecMoq()
        {
            //Arrange
            ProduitDTO produitTest = new ProduitDTO(1,1,"oui",13,10,"dv");
            //Act
            var actionResult = produitController.PostProduit(new ProduitDTO()).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Produit>), "la reponse n'est pas de type ActionResult<produit>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "la reponse n'est pas de type CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Produit), "la reponse n'est pas de type Produit");
        }

        [TestMethod()]
        public void PostProduitTest_InvalidInput_ReturnsBadRequest_avecMoq()
        {
            //Arrange   
            ProduitDTO produitTest = new ProduitDTO();
            produitController.ModelState.AddModelError("NomProduit", "Le nom du produit est obligatoire");
            //Act
            var actionResult = produitController.PostProduit(produitTest).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Produit>), "la reponse n'est pas de type ActionResult<produit>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult), "la reponse n'est pas de type BadRequestResult");
        }

        [TestMethod()]
        public void DeleteProduitTest_AvecMoq()
        {
            //Arrange
            Produit produitBase = new Produit(5,5,5,"Vélo de ville Nakamura E-City",1300,10,"Vélo de ville électrique idéal pour les trajets quotidiens.");
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(produitBase);
            //Act
            var actionResult = produitController.DeleteProduit(5).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NoContentResult), "la reponse n'est pas de type NoContentResult");
        }
        
        [TestMethod()]
        public void DeleteProduitTest_InvalidId_ReturnsNotFound_avecMoq()
        {
            //Arrange
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Produit)null);
            //Act
            var actionResult = produitController.DeleteProduit(0).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult), "la reponse n'est pas de type NotFoundResult");
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockRepository = null;
            produitController = null;
        }
    }
}