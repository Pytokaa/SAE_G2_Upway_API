using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_G2_Upway_APITests.Controllers.DBTests
{
    [TestClass]
    public class CommandesControllerDbTests
    {
        private UpwayDBContext? context;
        private ICommandeRepository? dataRepository;
        private CommandesController? controller;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
            context = new UpwayDBContext(builder.Options);
            dataRepository = new CommandeManager(context);
            controller = new CommandesController(dataRepository);
        }

        [TestMethod]
        public void GetAllCommandes_Succeed()
        {
            //Act
            var actual_commandes = controller.GetCommandes().Result;
            var expected_commandes = context.Commandes.ToList();
            //Assert
            CollectionAssert.AreEqual(actual_commandes.Value.ToList(), expected_commandes, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetCommandeById_ValidIdPassed_CommandeReturned()
        {
            //Act
            var actual_commande = controller.GetCommandeById(1).Result;
            var expected_commande = context.Commandes.FirstOrDefault(x => x.IdCommande == 1);
            //Assert
            Assert.AreEqual(actual_commande.Value, expected_commande, "Les commandes ne correspondent pas");
        }

        [TestCleanup]
        public void Cleanup()
        {
            context = null;
            controller = null;
            dataRepository = null;
        }
    }
}
