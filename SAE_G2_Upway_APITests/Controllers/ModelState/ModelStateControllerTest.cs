using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace SAE_G2_Upway_APITests.Controllers.ModelState
{
    public class ModelStateControllerTest : Controller
    {
        public ModelStateControllerTest()
        {
            ControllerContext = new Mock<ControllerContext>().Object;
        }

        public bool TestTryValidateModel(object model)
        {
            return TryValidateModel(model);
        }
    }
}
