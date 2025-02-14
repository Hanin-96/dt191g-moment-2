using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using moment2.Models;

namespace moment2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var welcomeInfo = new InfoModel
            {
                title = "Välkommen till Moment 2",
                description = "Pokemon innehåll",
                date = DateTime.Today
            };

            return View(welcomeInfo);
        }

        
    }
}
