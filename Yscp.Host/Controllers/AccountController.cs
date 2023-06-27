using Microsoft.AspNetCore.Mvc;
using Yscp.Data.Healper;
using Yscp.Data.Models.ViewModels;
using Yscp.Services.Interfaces;

namespace Yscp.Host.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _services;
        public AccountController(IAccountServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.LoginAsync(model);
                if (result.Success)
                {
                    return RedirectToAction("Index","Home");
                }

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Registerview model)
        {
            if (ModelState.IsValid)
            {

                var result = await _services.RegisterAsync(model);
                if (result.Success)
                {

                    return RedirectToAction("Login","Account");
                }
               
            }
            return View();
        }

    }
}
