using DemoMVC.BLL.Services.Auto;
using DemoMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DemoMVC.Controllers
{
    public class AutoController : Controller
    {
        private readonly IAutoService _autoService;
        private readonly ILogger<AutoController> _logger;
        public AutoController(IAutoService autoService, ILogger<AutoController> logger)
        {
            _autoService = autoService;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            List<AutoModel> autos;
            try
            {
                autos = _autoService.GetAllAutos();
                _logger.LogInformation("Managed to get all the autos");
                _logger.LogDebug("this is a debug log");
                _logger.LogWarning("this is a warning log");
                _logger.LogError("this is an error log");
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all the autos: {e.Message}");
                throw;
            }
            return View(autos);
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
