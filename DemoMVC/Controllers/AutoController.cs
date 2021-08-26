using DemoMVC.BLL.Services.Auto;
using DemoMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    

    public class AutoController : Controller
    {
        private readonly IAutoService _autoService;
        public AutoController(IAutoService autoService)
        {
            _autoService = autoService;
        }
        
        public IActionResult Index()
        {
            return View(_autoService.GetAllAutos());
        }
        [Authorize]
        public IActionResult Detail(int id)
        {
           
            return View(_autoService.GetAutoByID(id));
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult AddAuto()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult AddAuto(AutoModel auto)
        {
            if (ModelState.IsValid)
            {
                auto = _autoService.AddAuto(auto);
                return RedirectToAction("Detail", new { id = auto.Id });
            }
            return View(auto);
        }
    }
}
