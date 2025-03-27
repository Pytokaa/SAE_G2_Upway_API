using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Moq;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Controllers.DTO;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_G2_Upway_APITests.Controllers.Moq
{
    [TestClass()]
    public class VelosControllerTestsMoq
    {
        private VelosController? controller;
        private Mock<IDataRepository<Velo, VeloDtoGet>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Velo, VeloDtoGet>>();
            controller = new VelosController(mockRepository.Object);
        }

        [TestMethod]
        public void GetAllVelosMoq_Succeed()
        {
            //Arrange
            List<VeloDtoGet> lesVelos = new List<VeloDtoGet>([
                new VeloDtoGet(new Velo(1), true),
                new VeloDtoGet(new Velo(2), true),
                new VeloDtoGet(new Velo(3), true)
                ]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(lesVelos);
            //Act
            var actual_velos = controller.GetVelos().Result;
            //Assert
            CollectionAssert.AreEqual(actual_velos.Value.ToList(), lesVelos, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetVeloByIdMoq_ValidIdPassed_VeloReturned()
        {
            //Arrange
            Velo velo = new Velo(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(velo);
            //Act
            var actual_velo = controller.GetVeloById(1).Result;
            //Assert
            Assert.AreEqual(actual_velo.Value, velo, "Les vélos ne correspondent pas");
        }

        [TestMethod]
        public void GetVeloByIdMoq_InvalidIdPassed_NotFoundReturned()
        {
            Velo velo = null;
            ActionResult<Velo> actionResult = new ActionResult<Velo>(velo);
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(actionResult);
            //Act
             var actual_velo = controller.GetVeloById(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_velo.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod]
        public void PutVeloMoq_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            Velo velo = new Velo(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(velo);
            Velo updated_velo = new Velo(1,1,1,1,1,1,1,10,1,1,"Courbe",2018,false,2,"Sinistré");
            //Act
            var action_result = controller.PutVelo(1, new VeloDTO(updated_velo)).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod]
        public void PutVeloMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.PutVelo(0, new VeloDTO(new Velo(0))).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod]
        public void PostVeloMoq_ValidVeloPassed_CreatedAtActionReturned()
        {
            //Arrange
            Velo velo = new Velo(1);
            //Act
            var action_result = controller.PostVelo(new VeloDTO(velo)).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtAction");
        }

        [TestMethod]
        public void PostVeloMoq_InvalidVeloPassed_BadRequestReturned()
        {
            //Arrange
            Velo velo = new Velo(-1);
            controller.ModelState.AddModelError("ID", "L'ID ne peut aps être négatif");
            //Act
            var action_result = controller.PostVelo(new VeloDTO(velo)).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(BadRequestObjectResult), "Pas un BadRequest");
        }

        [TestMethod]
        public void DeleteVeloMoq_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            Velo velo = new Velo(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(velo);
            //Act
            var action_result = controller.DeleteVelo(1).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod]
        public void DeleteVeloMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.DeleteVelo(0).Result;
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