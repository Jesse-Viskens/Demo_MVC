
using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        [Authorize]
        public IActionResult Detail(int id)
        {
            var autos = Context.Autos.Where(a => a.Id == id);
            return View(autos.FirstOrDefault());
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
                return RedirectToAction("Detail", new { id = auto.Id });
            }
            return View(auto);
        }
    }
}
