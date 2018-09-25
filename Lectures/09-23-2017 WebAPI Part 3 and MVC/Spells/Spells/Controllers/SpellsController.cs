using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spells.Controllers
{
    public class SpellsController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post([FromBody] string userString)
        {

            return Json("Some string");
        }
    }
}
