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
    public class CategoriesVeloControllerTestsMoq
    {
        private CategoriesVeloController? controller;
        private Mock<IDataRepository<CategorieVelo, CategorieVelo>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<CategorieVelo, CategorieVelo>>();
            controller = new CategoriesVeloController(mockRepository.Object);
        }

        [TestMethod]
        public void GetAllCategories_Succeed()
        {
            //Arrange
            var expected_cateAccs = new List<CategorieVelo>([
                new CategorieVelo(1, "VTC"),
                new CategorieVelo(2, "VTT"),
                new CategorieVelo(3, "BMX")]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(expected_cateAccs);
            //Act
            var actual_cateAccs = controller.GetCategoriesVelo().Result;
            //assert
            CollectionAssert.AreEqual(actual_cateAccs.Value.ToList(), expected_cateAccs, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetCategorieById_ValidIdPassed_CategorieReturned()
        {
            //Arrange
            var expected_cateAcc = new CategorieVelo(1, "VTT");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(expected_cateAcc);
            //Act
            var actual_cateAcc = controller.GetCategorieVeloById(1).Result;
            //Assert
            Assert.AreEqual(actual_cateAcc.Value, expected_cateAcc, "Les catégorie Velo ne correspondent pas");
        }

        [TestMethod]
        public void GetCategorieById_InvalidIdPassed_NotFoundReturned()
        {
            //Arrange
            CategorieVelo categorieVelo = null;
            ActionResult<CategorieVelo> action_result = new ActionResult<CategorieVelo>(categorieVelo);
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(action_result);
            //Act
            var actual_categoriev = controller.GetCategorieVeloById(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_categoriev.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod]
        public void PutCategorie_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            var original_cateAcc = new CategorieVelo(1, "TVT");
            var modified_cateAcc = new CategorieVelo(1, "VTT");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(original_cateAcc);
            //Act
            var action_result = controller.PutCategorieVelo(1, modified_cateAcc).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod]
        public void PutCategorie_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.PutCategorieVelo(0, new CategorieVelo()).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostCategorie_ValidCategoriePassed_CreatedAtActionResult()
        {
            //Arrange
            var newCate = new CategorieVelo(1, "VTT");
            //Act
            var action_result = controller.PostCategorieVelo(newCate).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtAction");
        }

        [TestMethod]
        public void PostCategorie_InvalidCategoriePassed_BadRequestObjectReturned()
        {
            //Arrange
            var newCate = new CategorieVelo();
            controller.ModelState.AddModelError("ID", "Aucun ID n'a été renseigné");
            //Act
            var action_result = controller.PostCategorieVelo(newCate).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(BadRequestObjectResult), "Pas une BadRequest");
        }

        [TestMethod]
        public void DeleteCategorie_ValidIdPassed_NoContentReturned()
        {
            //Assert
            var cate = new CategorieVelo(1, "VTT");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cate);
            //Act
            var action_result = controller.DeleteCategorieVelo(1).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod]
        public void DeleteCategorie_invalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.DeleteCategorieVelo(0).Result;
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
