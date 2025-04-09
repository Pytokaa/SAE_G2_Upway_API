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
        public void GetRapportsInspection_Succceed()
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

        [TestCleanup]
        public void Cleanup() 
        {
            mockRepository = null;
            controller = null;
        }

    }
}