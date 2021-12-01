using Crossing.API.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crossing.API.Controllers
{
    [ApiController]
    [Route("/test")]
    public class TestController : ControllerBase
    {

        private readonly CrossingInfoContext db;
        public TestController(CrossingInfoContext BorderInfoContext)
        {
            db = BorderInfoContext ?? throw new ArgumentNullException(nameof(BorderInfoContext));
        }
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok();
        }

    }
}
