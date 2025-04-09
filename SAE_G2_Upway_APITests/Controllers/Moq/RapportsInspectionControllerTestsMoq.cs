using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SAE_G2_Upway_APITests.Controllers.Moq
{
    [TestClass()]
    public class RapportsInspectionControllerTestsMoq
    {
        private RapportsInspectionController? controller;
        private Mock<IDataRepository<RapportInspection, RapportInspection>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<RapportInspection, RapportInspection>>();
            controller = new RapportsInspectionController(mockRepository.Object);
        }

        [TestMethod()]
        public void GetRapportsInspectionMoq_Succceed()
        {
            //Arrange
            var expected_rapports = new List<RapportInspection>([
                new RapportInspection(1),
                new RapportInspection(2),
                new RapportInspection(3)
                ]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(expected_rapports);
            //Act
            var actual_rapports = controller.GetRapportsInspection().Result;
            //Assert
            CollectionAssert.AreEqual(actual_rapports.Value.ToList(), expected_rapports, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetRapportByIdVeloMoq_ValidIdPassed_RapportReturned()
        {
            //Arrange
            var expected_rapport = new RapportInspection(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(expected_rapport);
            //Act
            var actual_rapport = controller.GetRapportInspectionByIdVelo(1).Result;
            //Assert
            Assert.AreEqual(actual_rapport.Value, expected_rapport, "Les rapports ne correspondent pas");
        }

        [TestMethod]
        public void GetRapportByIdVeloMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Arrange
            RapportInspection? rapport = null;
            ActionResult<RapportInspection>? action_result = new ActionResult<RapportInspection>(rapport);
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(action_result);
            //Act
            var actual_rapport = controller.GetRapportInspectionByIdVelo(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_rapport.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod]
        public void PutRapportMoq_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            var original_rapport = new RapportInspection(1);
            var modified_rapport = new RapportInspection(1, 1, DateTime.Parse("2025-03-03"), "Val-de-Loire", "Volé", "Disparu Porte de la Chapelle, contactez Michel SAEZ au +4179 792 48 56");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(original_rapport);
            //Act
            var action_result = controller.PutRapportInspection(1, modified_rapport).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        } 

        [TestMethod]
        public void PutRapportMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.PutRapportInspection(0, new RapportInspection(0));
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod]
        public void PostRapportMoq_ValidRapportPassed_CreatedAtActionReturned()
        {
            //Arrange
            var new_rapport = new RapportInspection(1);
            //Act
            var action_result = controller.PostRapportInspection(new_rapport).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(CreatedAtActionResult), "Pas un NoContent");
        }

        [TestMethod]
        public void PostRapportMoq_InvalidRapportPassed_BadRequestObjectReturned()
        {
            //Arrange
            var new_rapport = new RapportInspection(0);
            controller.ModelState.AddModelError("ID", "L'ID ne peut pas être inférieur à 1");
            //Act
            var action_result = controller.PostRapportInspection(new_rapport).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(BadRequestObjectResult), "Pas une BadRequest");
        }

        [TestMethod]
        public void DeleteRapportMoq_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            var rapport = new RapportInspection(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(rapport);
            //Act
            var action_result = controller.DeleteRapportInspection(1).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod]
        public void DeleteRapportMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.DeleteRapportInspection(0).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            mockRepository = null;
            controller = null;
        }

    }
}