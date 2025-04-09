using SAE_G2_Upway_API.Controllers.DTO.DtoGet;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Models.DataManager;
using Microsoft.AspNetCore.Mvc;

namespace SAE_G2_Upway_APITests.Controllers.DBTests
{
    [TestClass]
    public class ClientControllerDbTests
    {
        private UpwayDBContext? context;
        private IDataRepository<Client, Client>? dataRepository;
        private ClientsController? controller;
        

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
            context = new UpwayDBContext(builder.Options);
            dataRepository = new ClientManager(context);
            controller = new ClientsController(dataRepository);
        }

        [TestMethod]
        public void GetAllClients_Succeed()
        {
            //Act
            var actual_clients = controller.GetClients().Result;
            var expected_clients = context.Clients.OrderBy(x => x.Idclient).ToList();
            //Assert
            CollectionAssert.AreEqual(actual_clients.Value.ToList(), expected_clients, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetClientById_ValidIdPassed_ClientReturned()
        {
            //Act
            var actual_client = controller.GetClientById(1).Result;
            var expected_client = context.Clients.FirstOrDefault(x => x.Idclient == 1);
            //Assert
            Assert.AreEqual(actual_client.Value, expected_client, "Les clients ne correspondent pas");
        }

        [TestMethod]
        public void GetClientById_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.GetClientById(0).Result;
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
