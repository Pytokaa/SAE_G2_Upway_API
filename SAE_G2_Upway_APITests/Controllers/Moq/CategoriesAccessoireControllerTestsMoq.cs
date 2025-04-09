using Microsoft.AspNetCore.Mvc;
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
            var expected_cateAccs = new List<CategorieAccessoire>([
                new CategorieAccessoire(1, "Casque"),
                new CategorieAccessoire(2, "Gants"),
                new CategorieAccessoire(3, "Truc")]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(expected_cateAccs);
            //Act
            var actual_cateAccs = controller.GetCategoriesAccessoire().Result;
            //assert
            CollectionAssert.AreEqual(actual_cateAccs.Value.ToList(), expected_cateAccs, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetCategorieById_ValidIdPassed_CategorieReturned()
        {
            //Arrange
            var expected_cateAcc = new CategorieAccessoire(1, "Gants");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(expected_cateAcc);
            //Act
            var actual_cateAcc = controller.GetCategorieAccessoireById(1).Result;
            //Assert
            Assert.AreEqual(actual_cateAcc.Value, expected_cateAcc, "Les catégorie accessoire ne correspondent pas");
        }

        [TestMethod]
        public void GetCategorieById_InvalidIdPassed_NotFoundReturned()
        {
            //Arrange
            CategorieAccessoire catA = null;
            ActionResult<CategorieAccessoire> action_result = new ActionResult<CategorieAccessoire>(catA);
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(action_result);
            //Act
            var actual_catA = controller.GetCategorieAccessoireById(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_catA.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod]
        public void PutCategorie_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            var original_cateAcc = new CategorieAccessoire(1, "Gatns");
            var modified_cateAcc = new CategorieAccessoire(1, "Gants");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(original_cateAcc);
            //Act
            var action_result = controller.PutCategorieAccessoire(1, modified_cateAcc).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod]
        public void PutCategorie_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.PutCategorieAccessoire(0, new CategorieAccessoire()).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostCategorie_ValidCategoriePassed_CreatedAtActionResult()
        {
            //Arrange
            var newCate = new CategorieAccessoire(1, "Gants");
            //Act
            var action_result = controller.PostCategorieAccessoire(newCate).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtAction");
        }

        [TestMethod]
        public void PostCategorie_InvalidCategoriePassed_BadRequestObjectReturned()
        {
            //Arrange
            var newCate = new CategorieAccessoire();
            controller.ModelState.AddModelError("ID", "Aucun ID n'a été renseigné");
            //Act
            var action_result = controller.PostCategorieAccessoire(newCate).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(BadRequestObjectResult), "Pas une BadRequest");
        }

        [TestMethod]
        public void DeleteCategorie_ValidIdPassed_NoContentReturned()
        {
            //Assert
            var cate = new CategorieAccessoire(1, "Gants");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cate);
            //Act
            var action_result = controller.DeleteCategorieAccessoire(1).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod]
        public void DeleteCategorie_invalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.DeleteCategorieAccessoire(0).Result;
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
