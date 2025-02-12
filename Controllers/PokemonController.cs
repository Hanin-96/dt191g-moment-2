using Microsoft.AspNetCore.Mvc;

namespace moment2.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Pokemon()
        {
            return View();
        }
    }
}
