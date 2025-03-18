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

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class ClientsControllerTests
    {
        private UpwayDBContext? context;
        private ClientsController? controller;
        private IDataRepository<Client> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=localhost;port=5432;Database=SAE_G2_Upway; uid=postgres; password=postgres;");
            context = new UpwayDBContext(builder.Options);
            dataRepository = new ClientManager(context);
            controller = new ClientsController(dataRepository);
        }

        [TestMethod()]
        public void GetAllClients_Succeed()
        {
            //Act
            var actual_users = controller.GetClients().Result;
            var expected_users = context.Clients.ToList();
            //Assert
            CollectionAssert.AreEqual(actual_users.Value.ToList(), expected_users, "Les listes ne corrrespondent pas");
        }

        

        [TestCleanup]
        public void Clean()
        {
            context = null;
            controller = null;
        }
    }
}