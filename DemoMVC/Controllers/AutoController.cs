
using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.Controllers
{
    public class AutoController : Controller
    {
        VoertuigDbContext Context;
        public AutoController(VoertuigDbContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View(Context.Autos);
        }
        public IActionResult Detail(int id)
        {
            var auto = Context.Autos.Where(a => a.Id == id);
            return View(auto.FirstOrDefault());
        }
        public IActionResult AddAuto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAuto(AutoModel auto)
        {
            if (ModelState.IsValid)
            {
                Context.Autos.Add(auto);
                Context.SaveChanges();
                int id = auto.Id;
                return RedirectToAction("Detail", new { id = auto.Id });
            }
            return View(auto);
        }
    }
}
