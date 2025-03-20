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

namespace SAE_G2_Upway_API.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTestsMoq
    {
        private LoginController? controller;
        private Mock<IDataRepository<Client>> mockRepository;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IDataRepository<Client>>();
            controller = new LoginController(mockRepository.Object);
        }

        [TestMethod]
        public void Login_ValidUserPassed_OKReturned()
        {
            //Arrange
            Client client = new Client(1, 1, "Pendragon", "Arthur", "arth.pend@kaamelott.uk", "0678912345", "K@@mel011");
            //Act

            //Assert

        }

        [TestCleanup]
        public void Clean()
        {
            mockRepository = null;
            controller = null;
        }
    }
}