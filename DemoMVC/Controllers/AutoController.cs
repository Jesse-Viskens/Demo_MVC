
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
        List<AutoModel> autolijst = new List<AutoModel>();
        public AutoController()
        {
            AutoModel autoModel = new AutoModel();
            autoModel.Id = AutoModel.AutosCreated;
            autoModel.KilometerStand = 150000;
            autoModel.Merk = "Toyota";
            autoModel.Type = "Auris";

            AutoModel autoModel2 = new AutoModel();
            autoModel2.Id = AutoModel.AutosCreated;
            autoModel2.KilometerStand = 20;
            autoModel2.Merk = "BMW";
            autoModel2.Type = "109D";

            autolijst.Add(autoModel);
            autolijst.Add(autoModel2);
        }
        public IActionResult Index()
        {
            return View(autolijst);
        }
        public IActionResult Detail(int id)
        {
            return View(autolijst[id - 1]);
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
                auto.Id = AutoModel.AutosCreated;
                autolijst.Add(auto);
                return RedirectToAction("Detail", auto.Id);
            }
            return View(auto);
        }
    }
}
