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
            Client client = new Client { };

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