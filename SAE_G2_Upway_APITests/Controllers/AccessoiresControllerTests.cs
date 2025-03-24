using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private UpwayDBContext dbContext;
        private AccessoiresController accessoiresController;
        private IDataRepository<Accessoire, AccessoireDtoGet> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=localhost;port=5432;Database=SAE_G2_Upway; uid=postgres; password=postgres;");
            dbContext = new UpwayDBContext(builder.Options);
            dataRepository = new AccessoireManager(dbContext);
            accessoiresController = new AccessoiresController(dataRepository);
        }
        
        [TestMethod()]
        public void AccessoiresControllerTest()
        {
            var accessoiresController = new AccessoiresController(dataRepository);
            Assert.IsNotNull(accessoiresController);
            Assert.IsInstanceOfType(accessoiresController, typeof(AccessoiresController));
        }

        [TestMethod()]
        public void GetAccessoiresTest_ReturnsOK()
        {
            var result = accessoiresController.GetAccessoires().Result;
            
            List<AccessoireDtoGet> accessoiresDto = new List<AccessoireDtoGet>();

            foreach (var item in result.Value)
            {
                AccessoireDtoGet accessoireDtoGet = item;
                accessoiresDto.Add(accessoireDtoGet);
            }
            
            List<Accessoire> accessoiresBase = dbContext.Accessoires.ToList();
            
            List<AccessoireDtoGet> lesAccessoires = new List<AccessoireDtoGet>();
            foreach (var acc in accessoiresBase) // Maintenant, c'est une liste en mémoire
            {
                lesAccessoires.Add(new AccessoireDtoGet()
                {
                    Nom = acc.Produit.NomProduit,
                    Prix = acc.Produit.PrixProduit,
                    Url = acc.Produit.Photo.Url,
                    Marque = acc.Produit.Marque.NomMarque,
                    Categorie = acc.CategorieAccessoire.NomCatA,
                    DateAccessoire = acc.DateAccessoire,
                });
            }
            CollectionAssert.AreEqual(lesAccessoires, accessoiresDto, "Les 2 lists ne sont pas du egals");
        }

        [TestMethod()]
        public void GetAccessoireByIdTest_ReturnsOK_AvecMoq()
        {
            Accessoire accessoireTest = new Accessoire(
                5,
                35,
                5, 
                new DateTime(2023-01-29-23-00-00)
                );

            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
            
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            var actionResult = accessoireController.GetAccessoireById(5).Result;
            Accessoire result = new Accessoire(
                actionResult.Value.IdAccessoire,
                actionResult.Value.IdProduit,
                actionResult.Value.IdCatA,
                actionResult.Value.DateAccessoire
            );
            
            Assert.IsNotNull(actionResult, "actionResult != null");
            Assert.IsNotNull(actionResult.Value, "actionResult.Value != null");
            Assert.AreEqual(accessoireTest, result, "Accessoire test n'est ppas egal au resultat");
        }

        [TestMethod()]
        public void GetAccessoireByIdTest_ReturnsNotFound_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            var actionResult = accessoireController.GetAccessoireById(0).Result;
            Assert.IsNotNull(actionResult, "la reponse est null");
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult), "la reponse n'est pas de type NotFoundResult");
        }

        [TestMethod()]
        public void PutAccessoireTest_AvecMoq()
        {
            Accessoire accessoireTest = new Accessoire(
                5,
                35,
                5, 
                new DateTime(2023-01-29-23-00-00)
            );
            AccessoireDTO accessoireModif = new AccessoireDTO(
                35,
                5,
                new DateTime(2023-03-29-23-00-00)
                );
            
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            var actionResult = accessoireController.PutAccessoire(accessoireTest.IdAccessoire, accessoireModif).Result;
            
            Assert.IsNotNull(actionResult, "la reponse est null");
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "la reponse n'est pas correctement");
        }

        [TestMethod()]
        public void PutAccessoireTest_InvalidId_ReturnsNotFound_AvecMoq()
        {
            AccessoireDTO accessoireModif = new AccessoireDTO(
                35,
                5,
                new DateTime(2023-03-29-23-00-00)
            );
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Accessoire)null);
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            var actionResult = accessoireController.PutAccessoire(0, accessoireModif).Result;
            Assert.IsInstanceOfType(actionResult,typeof(NotFoundResult), "la reponse est null");
        }

        [TestMethod()]
        public void PutAccessoireTest_InvalidInput_ReturnsBadRequest_AvecMoq()
        {
            AccessoireDTO accessoireModif = new AccessoireDTO(
                0,
                5,
                new DateTime(2023-03-29-23-00-00)
            );
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            Accessoire accessoireTest = new Accessoire(
                5,
                35,
                5, 
                new DateTime(2023-01-29-23-00-00)
            );
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            accessoireController.ModelState.AddModelError("IdProduit", "l'id du produit ne peut pAS ETRE EGAL A 0");
            
            var actionResult = accessoireController.PutAccessoire(5, accessoireModif).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult), "la reponse est null");
        }

        [TestMethod()]
        public void PostAccessoireTest_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            var accessoireController = new AccessoiresController(mockRepository.Object);

            AccessoireDTO accessoireTest = new AccessoireDTO(
                5,
                37,
                DateTime.Now
            );
            var actionResult = accessoireController.PostAccessoire(accessoireTest).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Accessoire>), "la reponse est null");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "la reponse est null");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Accessoire), "la reponse est null");
        }

        [TestMethod()]
        public void PostAccessoireTest_InvalidInput_ReturnsBadRequest_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            AccessoireDTO accessoireTest = null;
            
            accessoireController.ModelState.AddModelError("accessoireTest", "l'accessoire ne peut pas etre null");
            
            var actionResult = accessoireController.PostAccessoire(accessoireTest).Result;
            
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Accessoire>), "actionresult n'est pas un actionResult");
            
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult), "la reponse n'est pas un badrequestobject result");
        }

        [TestMethod()]
        public void DeleteAccessoireTest()
        {
            Accessoire accessoireTest = new Accessoire(
                5,
                35,
                5, 
                new DateTime(2023-01-29-23-00-00)
            );
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            mockRepository.Setup(x => x.GetByIdAsync(5).Result).Returns(accessoireTest);
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            var actionResult = accessoireController.DeleteAccessoire(5).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "la reponse n'est pas un nocontentresult");
        }

        [TestMethod()]
        public void DeleteAccessoireTest_InvalidId_ReturnsNotFound_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Accessoire, AccessoireDtoGet>>();
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns((Accessoire)null);
            var accessoireController = new AccessoiresController(mockRepository.Object);
            
            var actionResult = accessoireController.DeleteAccessoire(0).Result;
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult), "la reponse n'est pas un notfoundresult");
        }

        [TestCleanup]
        public void Cleanup()
        {
            dbContext = null;
            dataRepository = null;
            accessoiresController = null;
        }
    }
}