using Microsoft.AspNetCore.Mvc;
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
            //Act
             var action_result = controller.GetVeloById(0).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            mockRepository = null;
            controller = null;
        }
    }
}