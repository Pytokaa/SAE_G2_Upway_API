using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_APITests.Controllers.DBTests
{
    [TestClass]
    public class MarquesControllerDbTests
    {
        private UpwayDBContext? context;
        private IDataRepository<Marque, Marque>? dataRepository;
        private MarquesController? controller;


        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
            context = new UpwayDBContext(builder.Options);
            dataRepository = new MarqueManager(context);
            controller = new MarquesController(dataRepository);
        }

        [TestMethod]
        public void MarqueControllerTest()
        {
            //Assert
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void GetAllClients_Succeed()
        {
            //Act
            var actual_marques = controller.GetMarques().Result;
            var expected_marques = context.Marques.ToList();
            //Assert
            CollectionAssert.AreEqual(actual_marques.Value.ToList(), expected_marques, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetClientById_ValidIdPassed_ClientReturned()
        {
            //Act
            var actual_marque = controller.GetMarqueById(1).Result;
            var expected_marque = context.Marques.FirstOrDefault(x => x.IdMarque == 1);
            //Assert
            Assert.AreEqual(actual_marque.Value, expected_marque, "Les clients ne correspondent pas");
        }

        [TestMethod]
        public void GetClientById_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.GetMarqueById(0).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(NotFoundResult), "Problème dans la base de données : Index 0 détecté");
        }

        [TestCleanup]
        public void Cleanup()
        {
            context = null;
            dataRepository = null;
            controller = null;
        }
    }
}