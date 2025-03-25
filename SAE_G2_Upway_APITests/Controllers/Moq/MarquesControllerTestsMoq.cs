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

        [TestCleanup]
        public void Cleanup()
        {
            mockRepository = null;
            controller = null;
        }

    }
}