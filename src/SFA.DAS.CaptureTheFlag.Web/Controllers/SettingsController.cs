using System;
using DAS_Capture_The_Flag.Data;
using DAS_Capture_The_Flag.Models.Settings;
using Microsoft.AspNetCore.Mvc;

namespace DAS_Capture_The_Flag.Controllers
{
    public class SettingsController : Controller
    {

        private readonly ApplicationDbContext db; // Database
        //private readonly SettingsModel db;

        public SettingsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(SettingsModel settingsModel)
        {
            db.Settings.Add(settingsModel);
            db.SaveChanges();
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get the default settings

            var model = new SettingsModel() 
            {
                
                MusicVolume = 3,
                SoundEffectsVolume = 3,
                GraphicsDetail = "Medium"
            };

            return View("Index", model);
        }

        //[HttpPost]
        //public IActionResult Post(SettingsModel model)
        //{
        //    // Save the settings

        //    return View("Index", model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(SettingsModel model)
        {
            db.Add(model);
            return View("Index", model);
        }
    }
}