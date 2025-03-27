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
using SAE_G2_Upway_API.Controllers.DTO;

namespace SAE_G2_Upway_APITests.Controllers.Moq
{
    [TestClass()]
    public class ClientsControllerTestsMoq
    {
        private ClientsController? controller;
        private Mock<IDataRepository<Client, Client>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Client, Client>>();
            controller = new ClientsController(mockRepository.Object);
        }

        [TestMethod()]
        public void GetAllClientsMoq_Succeed()
        {
            //Arrange
            List<Client> clients = new List<Client>([
                new Client(1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011"),
                new Client(2, "Dagan", "Leo", "leo.dagan@carmelide.uk", "0666666666", "T0u&Le&Brûler"),
                new Client(3, "Du Lac", "Lancelot", "lancelot.dulac@kaamelott.uk", "0605030201", "1lF@utT0utF@1reS0itMême")
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
            Client client = new Client(1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
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
            Client client = null;
            ActionResult<Client> action_result = new ActionResult<Client>(client);
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(action_result);
            //Act
            var actual_client = controller.GetClientById(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_client.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod()]
        public void PutClientMoq_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            Client client = new Client(1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(client);
            ClientDTO modified_client = new ClientDTO(new Client(1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0123456789", "K@@mel011"));
            //Act
            var action_result = controller.PutClient(1, modified_client).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod()]
        public void PutClientMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Arrange
            Client client = new Client(0, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
            //Act
            var actual_result = controller.PutClient(0, new ClientDTO(client)).Result;
            //Assert
            Assert.IsInstanceOfType(actual_result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod()]
        public void PostClientMoq_ValidClientPassed_CreatedAtActionReturned()
        {
            //Arrange
            Client new_client = new Client(4, "Lenchanteur", "Merlin", "merlin.lenchanteur@demonpucelle.uk", "0661626364", "Pet1tEtM@rr0n");
            //Act
            var action_result = controller.PostClient(new ClientDTO(new_client)).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtAction");
        }

        [TestMethod()]
        public void PostClientMoq_InvalidClientPassed_BadRequestReturned()
        {
            //Arrange
            Client new_client = new Client();
            controller.ModelState.AddModelError("Password", "Aucun mot de passe n'a été renseigné");
            //Act
            var action_result = controller.PostClient(new ClientDTO(new_client)).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(BadRequestObjectResult), "Pas un BadRequest");
        }

        [TestMethod()]
        public void DeleteClient_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            Client client = new Client(1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(client);
            //Act
            var action_result = controller.DeleteClient(1).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod()]
        public void DeleteClient_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.DeleteClient(0).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestCleanup]
        public void Clean()
        {
            mockRepository = null;
            controller = null;
        }
    }
}