using Microsoft.AspNetCore.Mvc;

namespace labs1.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        
      
        
        public IActionResult About() { return View(); }

    }
}
