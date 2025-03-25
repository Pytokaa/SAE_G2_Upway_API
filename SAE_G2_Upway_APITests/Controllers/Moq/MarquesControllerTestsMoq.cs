using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

namespace SAE_G2_Upway_APITests.Controllers.Moq
{
    [TestClass()]
    public class MarquesControllerTestsMoq
    {
        private MarquesController? controller;
        private Mock<IDataRepository<Marque, Marque>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Marque, Marque>>();
            controller = new MarquesController(mockRepository.Object);
        }

        [TestMethod]
        public void GetAllMarquesMoq_Succeed()
        {
            //Arrange
            List<Marque> marques = new List<Marque>([
                new Marque(1,"Giant"),
                new Marque(2,"Btwin"),
                new Marque(3, "Moustache")
                ]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(marques);
            //Act
            var actual_marques = controller.GetMarques().Result;
            //Assert
            CollectionAssert.AreEqual(actual_marques.Value.ToList(), marques, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetMarqueByIdMoq_ValidIdPassed_MarqueReturned()
        {
            //Arrange
            Marque marque = new Marque(1, "Giant");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(marque);
            //Act
            var actual_marque = controller.GetMarqueById(1).Result;
            //Assert
            Assert.AreEqual(actual_marque.Value, marque, "Les marques ne correspondent pas");
        }

        [TestMethod]
        public void GetMarqueByIdMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.GetMarqueById(0).Result;
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