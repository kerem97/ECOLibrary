using Microsoft.AspNetCore.Mvc;

namespace ECOLibrary.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
