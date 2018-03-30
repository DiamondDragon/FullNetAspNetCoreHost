using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleHostApp.Controllers
{
    [Route("v1/api")]
    public class TestController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Result";
        }
    }
}
