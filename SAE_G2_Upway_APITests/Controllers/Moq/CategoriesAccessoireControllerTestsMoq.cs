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
    [TestClass]
    public class CategoriesAccessoireControllerTestsMoq
    {
        private CategoriesAccessoireController? controller;
        private Mock<IDataRepository<CategorieAccessoire, CategorieAccessoire>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<CategorieAccessoire, CategorieAccessoire>>();
            controller = new CategoriesAccessoireController(mockRepository.Object);
        }

        [TestMethod]
        public void GetAllCategories_Succeed()
        {
            //Arrange
            var expected_accessoires = new List<CategorieAccessoire>([
                new CategorieAccessoire(1, "Casque"),
                new CategorieAccessoire(2, "Gants"),
                new CategorieAccessoire(3, "Truc")]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(expected_accessoires);
            //Act
            var actual_accessoires = controller.GetCategoriesAccessoire().Result;
            //assert
            CollectionAssert.AreEqual(actual_accessoires.Value.ToList(), expected_accessoires, "Les listes ne correspondent pas");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            mockRepository = null;
            controller = null;
        }
    }
}
