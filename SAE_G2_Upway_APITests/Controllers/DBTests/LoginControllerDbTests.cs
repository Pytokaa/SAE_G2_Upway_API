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
using Microsoft.Extensions.Configuration;
using SAE_G2_Upway_API.Controllers.DTO;

namespace SAE_G2_Upway_APITests.Controllers.DBTests
{
    [TestClass]
    public class LoginControllerDbTests
    {
        private UpwayDBContext? context;
        private IDataRepository<Client, Client>? dataRepository;
        private LoginController? controller;
        private IConfiguration? config;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
            var confBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            config = confBuilder.Build();
            context = new UpwayDBContext(builder.Options);
            dataRepository = new ClientManager(context);
            controller = new LoginController(config, dataRepository);
            var initList = controller.GetClients().Result;
        }

        [TestMethod]
        public void Login_ValidClientPassed_OkReturned()
        {
            //Act
            var action_result = controller.Login("francky.lefripon@gmail.com", "CheveuxSpaghettis");
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(OkObjectResult), "Pas OK");
        }

        [TestCleanup]
        public void Cleanup()
        {
            config = null;
            context = null;
            dataRepository = null;
            controller = null;
        }
    }
}
