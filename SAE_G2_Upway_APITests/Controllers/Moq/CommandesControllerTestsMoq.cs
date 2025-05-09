﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
using SAE_G2_Upway_API.Controllers.DTO;

namespace SAE_G2_Upway_APITests.Controllers.Moq
{
    [TestClass()]
    public class CommandesControllerTestsMoq
    {
        private CommandesController? controller;
        private Mock<ICommandeRepository> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<ICommandeRepository>();
            controller = new CommandesController(mockRepository.Object);
        }


        [TestMethod()]
        public void GetAllCommandesMoq_Succeed()
        {
            //Arrange
            List<Commande> commandes = new List<Commande>([
                new Commande(1),
                new Commande(2),
                new Commande(3)
                ]);
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(commandes);
            //Act
            var actual_commandes = controller.GetCommandes().Result;
            //Assert
            CollectionAssert.AreEqual(actual_commandes.Value.ToList(), commandes, "Les listes ne correspondent pas");
        }

        [TestMethod()]
        public void GetCommandeByIdMoq_ValidIdPassed_CommandeReturned()
        {
            //Arrange
            Commande commande = new Commande(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(commande);
            //Act
            var actual_command = controller.GetCommandeById(1).Result;
            //Assert
            Assert.AreEqual(actual_command.Value, commande, "Pas la même commande");
        }

        [TestMethod()]
        public void GetCommandeByIdMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Arrange
            Commande commande = null;
            ActionResult<Commande> action_result = new ActionResult<Commande>(commande);
            mockRepository.Setup(x => x.GetByIdAsync(0).Result).Returns(action_result);
            //Act
            var actual_commande = controller.GetCommandeById(0).Result;
            //Assert
            Assert.IsInstanceOfType(actual_commande.Result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod()]
        public void PutCommandeMoq_ValidIdPassed_NoContentReturned()
        {
            Commande commande = new Commande(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(commande);
            CommandeDTO modified_commande = new CommandeDTO(new Commande(1, DateTime.Parse("16-03-1965"), 1, 1, 1, 1, 1, 1, 1, 1));
            //Act
            var action_result = controller.PutCommande(1, modified_commande).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod()]
        public void PutCommandeMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.PutCommande(0, new CommandeDTO(new Commande(0))).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod()]
        public void PostCommandeMoq_ValidCommandePassed_CreatedAtActionObjectReturned()
        {
            //Arrange
            CommandeDTO commandeDto = new CommandeDTO(new Commande(1));
            //Act
            var action_result = controller.PostCommande(commandeDto).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtAction");
        }

        [TestMethod()]
        public void PostCommandeMoq_InvalidCommandePassed_BadRequestReturned()
        {
            //Arrange
            Commande new_commande = new Commande();
            controller.ModelState.AddModelError("ID", "Aucun id n'a été renseigné");
            //Act
            var action_result = controller.PostCommande(new CommandeDTO(new_commande)).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(BadRequestObjectResult), "Pas un BadRequest");
        }

        [TestMethod()]
        public void DeleteCommandeMoq_ValidIdPassed_NoContentReturned()
        {
            //Arrange
            Commande commande = new Commande(1);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(commande);
            //Act
            var action_result = controller.DeleteCommande(1).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NoContentResult), "Pas un NoContent");
        }

        [TestMethod()]
        public void DeleteCommandeMoq_InvalidIdPassed_NotFoundReturned()
        {
            //Act
            var action_result = controller.DeleteCommande(0).Result;
            //Assert
            Assert.IsInstanceOfType(action_result, typeof(NotFoundResult), "Pas un NotFound");
        }

        [TestMethod()]
        public void GetCommandeByIdClientMoq_IdPassed_ListReturned()
        {
            //Arrange
            List<Commande> commandes = new List<Commande>([
                new Commande(1), 
                new Commande(2, DateTime.Parse("13/03/2003"), 1,1,1,1,1,1,1,1)
                ]);
            mockRepository.Setup(x => x.GetCommandesByIdClientAsync(1).Result).Returns(commandes);
            //Act
            var actual_commandes = controller.GetCommandesByClientId(1).Result;
            //Assert
            CollectionAssert.AreEqual(actual_commandes.Value.ToList(), commandes, "Les listes ne correspondent pas");
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockRepository = null;
            controller = null;
        }
    }
}