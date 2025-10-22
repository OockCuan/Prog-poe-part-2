using Microsoft.AspNetCore.Mvc;

namespace ProgPOE.Controllers
{
    public class ClaimsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
