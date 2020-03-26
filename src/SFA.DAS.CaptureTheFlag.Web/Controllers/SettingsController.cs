using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAS_Capture_The_Flag.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Get the settings

            var model = new SettingsModel() 
            { 
                MusicVolume = 3,
                SoundEffectsVolume = 3,
                GraphicsDetail = Graphics.Medium
            };

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Post(SettingsModel model)
        {
            // Save the settings
            
            return View("Index", model);
        }
    }
}