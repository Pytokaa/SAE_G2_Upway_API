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
    public class LoginControllerTestsMoq
    {
        private LoginController? controller;
        private Mock<IDataRepository<Client, Client>> mockRepository;
        private IConfiguration config;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Client, Client>>();
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            config = builder.Build();
            controller = new LoginController(config, mockRepository.Object);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(new List<Client>([
                new Client(1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011"),
                new Client(2, "Dagan", "Leo", "leo.dagan@carmelide.uk", "0666666666", "T0u&Le&Brûler"),
                new Client(3, "Du Lac", "Lancelot", "lancelot.dulac@kaamelott.uk", "0605030201", "1lF@utT0utF@1reS0itMême")
            ]));
            controller.GetClients();
        }

        [TestMethod]
        public void Login_ValidUserPassed_OkObjectReturned()
        {
            //Arrange
            Client client = new Client(1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
            //Act
            var action_result = controller.Login(client);
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(OkObjectResult), "Pas OK");
        }

        [TestMethod]
        public void Login_InvalidUserPassed_UnauthorizedReturned()
        {
            //Arrange
            Client client = new Client(4, "Lenchanteur", "Merlin", "merlin.lenchanteur@demonpucelle.uk", "0661626364", "Pet1tEtM@rr0n");
            //Act
            var action_result = controller.Login(client);
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(UnauthorizedResult), "Pas Unauthorized");
        }

        [TestCleanup]
        public void Clean()
        {
            mockRepository = null;
            config = null;
            controller = null;
        }
    }
}