using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetRegister.Data;
using VetRegister.Models;

namespace VetRegister.Controllers
{
    public class HomeController : Controller
    {
        private readonly VetRegisterDbContext data;

        public HomeController(VetRegisterDbContext data)
        {
            this.data = data;

    }


        public IActionResult Index() 
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
