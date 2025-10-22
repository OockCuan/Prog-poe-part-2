using Microsoft.AspNetCore.Mvc;

namespace ProgPOE.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reject()
        {
            return View();
        }
    }
}
