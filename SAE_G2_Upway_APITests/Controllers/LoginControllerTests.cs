using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers;
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
    public class LoginControllerTests
    {
        private UpwayDBContext dbContext;
        private LoginController controller;
        private IDataRepository<Client> dataRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("UpwayDBContext");
            dbContext = new UpwayDBContext(builder.Options);
            controller = new LoginController(dataRepository);
        }

        [TestMethod]
        public void Login_ValidUserPassed_OKReturned()
        {
            //Arrange
            Client client = new Client { Nomclient = "Durand", Prenomclient = "Pierre", Mailclient = "pierre.durand@gmail.com", Telephone = "0601020304", Password = "4083385F88700370B79A4B140347746E", IdFonction = 1 };
            //Act

            //Assert

        }

        [TestCleanup]
        public void Clean()
        {
            dbContext = null;
            controller = null;
        }
    }
}