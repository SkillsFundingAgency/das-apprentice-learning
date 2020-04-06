using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DAS_Capture_The_Flag.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GuestSignIn()
        {

            return RedirectToAction("Index", "Lobby", new { playerId = Guid.NewGuid() });
        }

        [HttpPost]
        public IActionResult SetName(SetNickNameViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("../SignIn/Index");

            }

            return RedirectToAction("FindGame", "Game");
        }
    }
}
