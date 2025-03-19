using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class ClientsControllerTestsMoq
    {
        private ClientsController? controller;
        private Mock<IDataRepository<Client>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Client>>();
            controller = new ClientsController(mockRepository.Object);
        }

        [TestMethod()]
        public void GetAllClientsMoq_Succeed()
        {
            //Arrange
            List<Client> clients = new List<Client>([
                new Client(1, 1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011"),
                new Client(2, 2, "Dagan", "Leo", "leo.dagan@carmelide.uk", "0666666666", "T0u&Le&Brûler"),
                new Client(3, 3, "Du Lac", "Lancelot", "lancelot.dulac@kaamelott.uk", "0605030201", "1lF@utT0utF@1reS0itMême")
            ]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(clients);
            //Act
            var actual_clients = controller.GetClients().Result;
            //Assert
            CollectionAssert.AreEqual(actual_clients.Value.ToList(), clients, "Les listes ne corrrespondent pas");
        }

        [TestMethod()]
        public void GetClientByIdMoq_ValidIdPassed_ClientReturned()
        {
            //Arrange
            Client client = new Client(1, 1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(client);
            //Act
            var actual_client = controller.GetClientById(1).Result;
            //Assert
            Assert.AreEqual(actual_client.Value, client, "Les clients ne correspondent pas");
        }

        [TestMethod()]
        public void GetClientByIdMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Arrange
            ActionResult<Client> actionresult = new NotFoundResult();
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(actionresult);
            //Act
            var actual_client = controller.GetClientById(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_client.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod()]
        public void GetClientByNameMoq_ValidNamePassed_ClientReturned()
        {
            //Arrange
            Client client = new Client(1, 1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
            mockRepository.Setup(x => x.GetByStringAsync("Pendragon").Result).Returns(client);
            //Act
            var actual_client = controller.GetClientByName("Pendragon").Result;
            //Arrange
            Assert.AreEqual(actual_client.Value, client, "Les clients ne correspondent pas");
        }

        [TestMethod()]
        public void GetClientByNameMoq_InvalidNamePassed_NotFoundReturned()
        {
            //Arrange
            ActionResult<Client> actionresult = new NotFoundResult();
            mockRepository.Setup(x => x.GetByStringAsync("Uther").Result).Returns(actionresult);
            //Act
            var actual_client = controller.GetClientByName("Uther").Result;
            //Assert
            Assert.IsInstanceOfType(actual_client.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestCleanup]
        public void Clean()
        {
            mockRepository = null;
            controller = null;
        }
    }
}