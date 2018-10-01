using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Spells.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spells.Controllers
{
    public class SpellsController : Controller
    {
        // Remember, this is not the way to do this. Use Dependency Injection from assignment 6 and onwards.
        public static SpellsDatabase spellsDatabase = new SpellsDatabase();

        public IActionResult Index()
        {
            return View(spellsDatabase);
        }
        
        public IActionResult ViewSpell(string id)
        {
            if (int.TryParse(id, out int index))
            {
                ViewData["id"] = id;
                return View(spellsDatabase.Get(index));
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Add()
        {
            if (Request.HasFormContentType)
            {
                if (Request.Form.TryGetValue("spellName", out StringValues spellValue))
                {
                    spellsDatabase.Add(spellValue[0]);
                }
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            if (Request.HasFormContentType)
            {
                if (Request.Form.TryGetValue("spellIndex", out StringValues spellIndex))
                {
                    if (int.TryParse(spellIndex, out int index))
                    {
                        spellsDatabase.RemoveAt(index);
                    }
                }
            }

            return RedirectToAction("index");
        }

        static SpellsController()
        {
            spellsDatabase.Add("Wingardium Levosa");
            spellsDatabase.Add("Experiamus");
        }
    }
}
