using Microsoft.AspNetCore.Mvc;

namespace moment2.Controllers
{
    public class WeightController : Controller
    {
        [HttpGet]
        public IActionResult Weight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Weight(int kilos)
        {
            //Kontrollerar inputsfältet
            if(kilos > 0)
            {
                ViewBag.Pikachu = kilos / 6;
            } else
            {
                ViewBag.Error = "Skriv in korrekt värde";
            }
            return View();
        }
    }
}
