using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_G2_Upway_API.Controllers.DTO.DtoGet;
using SAE_G2_Upway_API.Controllers;
using SAE_G2_Upway_API.Models.DataManager;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAE_G2_Upway_API.Migrations;

namespace SAE_G2_Upway_APITests.Controllers.DBTests
{
    [TestClass()]
    public class VelosControllerDbTests
    {
        private UpwayDBContext? context;
        private IDataRepository<Velo, VeloDtoGet>? dataRepository;
        private VelosController? controller;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<UpwayDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=SAE_G2_Upway; uid=staale; password=2yn32i;");
            context = new UpwayDBContext(builder.Options);
            dataRepository = new VeloManager(context);
            controller = new VelosController(dataRepository);
        }

        [TestMethod]
        public void GetAllVelos_Succeed()
        {
            //act
            var actual_velos = controller.GetVelos().Result;
            var expected_velos = context.VeloToDtoGet(context.Velos.ToList());
            //Assert
            CollectionAssert.AreEqual(actual_velos.Value.ToList(), expected_velos, "Les listes ne correspondent pas");
        }

        [TestMethod]
        public void GetVeloById_ValidIdPassed_VeloReturned()
        {
            //Act
            var actual_velo = controller.GetVeloById(1).Result;
            var expected_velo = context.Velos.FirstOrDefault(x => x.IdVelo == 1);
            //Assert
            Assert.AreEqual(actual_velo.Value, expected_velo, "les velos ne correspondent pas");
        }

        [TestMethod]
        public void GetVeloById_InvalidIdPassed_NotFoundReturned()
        {
            //act
            var action_result = controller.GetVeloById(0).Result;
            //Assert
            Assert.IsInstanceOfType(action_result.Result, typeof(NotFoundResult), "probleme dans la base de donnees : Index 0 detecte");

        }

        [TestCleanup]
        public void Cleanup()
        {
            context = null;
            dataRepository = null;
            controller = null;
        }
    }
}