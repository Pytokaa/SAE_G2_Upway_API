﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Protocol.Core.Types;
using SAE_G2_Upway_API.Controllers.DTO;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class AccessoiresControllerTests
    {
        private AccessoiresController? accessoiresController;
        private Mock<IDataRepository<Accessoire, AccessoireDtoGet>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            accessoiresController = new AccessoiresController(mockRepository.Object);
        }

        [TestMethod()]
        public void GetAccessoiresTest_ReturnsOK_AvecMoq()
        {
            //Arrange
            List<AccessoireDtoGet> accessoires = new List<AccessoireDtoGet>([
                new AccessoireDtoGet( 1,"Antivol Abus Bordo", 80, "images/accessoire/antivol_abus_bordo.jpg","Abus","Antivols",new DateTime(2024-11-10-00-00-00)),
                new AccessoireDtoGet( 2,"Casque Abus Hyban 2.0", 60, "images/accessoire/casque_abus_hyban.jpg","Abus","Sacoches et paniers",new DateTime(2022-10-14-00-00-00)),
                new AccessoireDtoGet( 3,"Antivol Kryptonite New York", 120, "images/accessoire/antivol_kryptonite_ny.jpg","Bosch","Casques",new DateTime(2022-12-10-00-00-00)),
            ]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(accessoires);
            //Act
            var actual_accessoires = accessoiresController.GetAccessoires().Result;
            //Assert
            CollectionAssert.AreEqual(actual_accessoires.Value.ToList(), accessoires, "Les listes ne correspondent pas");
        }

        [TestMethod()]
        public void GetAccessoireByIdTest_ReturnsOK_AvecMoq()
        {
            //Arrange
            Accessoire accessoireTest = new Accessoire(5, 35, 5, new DateTime(2023-01-29-23-00-00));
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
            //Act
            var actionResult = accessoiresController.GetAccessoireById(5).Result;
            // Assert
            Assert.IsNotNull(actionResult, "actionResult != null");
            Assert.IsNotNull(actionResult.Value, "actionResult.Value != null");
            Assert.AreEqual(accessoireTest, actionResult.Value, "Accessoire test n'est ppas egal au resultat");
        }

        [TestMethod()]
        public void GetAccessoireByIdTest_ReturnsNotFound_AvecMoq()
        {
            //Act
            var actionResult = accessoiresController.GetAccessoireById(0).Result;
            //Assert
            Assert.IsNotNull(actionResult, "la reponse est null");
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult), "la reponse n'est pas de type NotFoundResult");
        }

        [TestMethod()]
        public void PutAccessoireTest_AvecMoq()
        {
            //Arrange
            Accessoire accessoireTest = new Accessoire(5,35,5, new DateTime(2023-01-29-23-00-00));
            AccessoireDTO accessoireModif = new AccessoireDTO( 35, 5, new DateTime(2023-03-29-23-00-00) );
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
            //Act
            var actionResult = accessoiresController.PutAccessoire(accessoireTest.IdAccessoire, accessoireModif).Result;
            //Assert
            Assert.IsNotNull(actionResult, "la reponse est null");
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "la reponse n'est pas correctement");
        }

        [TestMethod()]
        public void PutAccessoireTest_InvalidId_ReturnsNotFound_AvecMoq()
        {
            //Arrance
            AccessoireDTO accessoireModif = new AccessoireDTO(
                35,
                5,
                new DateTime(2023-03-29-23-00-00)
            );
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Accessoire)null);
            //Act
            var actionResult = accessoiresController.PutAccessoire(0, accessoireModif).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult,typeof(NotFoundResult), "la reponse est null");
        }

        [TestMethod()]
        public void PutAccessoireTest_InvalidInput_ReturnsBadRequest_AvecMoq()
        {
            //Arrance
            AccessoireDTO accessoireModif = new AccessoireDTO(
                0,
                5,
                new DateTime(2023-03-29-23-00-00)
            );
            Accessoire accessoireTest = new Accessoire(
                5,
                35,
                5, 
                new DateTime(2023-01-29-23-00-00)
            );
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
            //Act
            accessoiresController.ModelState.AddModelError("IdProduit", "l'id du produit ne peut pAS ETRE EGAL A 0");
            
            var actionResult = accessoiresController.PutAccessoire(5, accessoireModif).Result;
            
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult), "la reponse est null");
        }

        [TestMethod()]
        public void PostAccessoireTest_AvecMoq()
        {
            //Arrange
            AccessoireDTO accessoireTest = new AccessoireDTO(
                5,
                37,
                DateTime.Now
            );
            //Act
            var actionResult = accessoiresController.PostAccessoire(accessoireTest).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Accessoire>), "la reponse est null");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "la reponse est null");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Accessoire), "la reponse est null");
        }

        [TestMethod()]
        public void PostAccessoireTest_InvalidInput_ReturnsBadRequest_AvecMoq()
        {
            //Arrange
            AccessoireDTO accessoireTest = null;
            accessoiresController.ModelState.AddModelError("accessoireTest", "l'accessoire ne peut pas etre null");
            //Act
            var actionResult = accessoiresController.PostAccessoire(accessoireTest).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Accessoire>), "actionresult n'est pas un actionResult");
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult), "la reponse n'est pas un badrequestobject result");
        }

        [TestMethod()]
        public void DeleteAccessoireTest()
        {
            //Arrange
            Accessoire accessoireTest = new Accessoire(5,35, 5, new DateTime(2023-01-29-23-00-00));
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
             //Act
            var actionResult = accessoiresController.DeleteAccessoire(5).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "la reponse n'est pas un nocontentresult");
        }

        [TestMethod()]
        public void DeleteAccessoireTest_InvalidId_ReturnsNotFound_AvecMoq()
        {
            //Arrange
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Accessoire)null);
            //Act
            var actionResult = accessoiresController.DeleteAccessoire(0).Result;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult), "la reponse n'est pas un notfoundresult");
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockRepository = null;
            accessoiresController = null;
        }
    }
}