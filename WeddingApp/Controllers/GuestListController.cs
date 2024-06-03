using Microsoft.AspNetCore.Mvc;

namespace WeddingApp.Controllers
{
    public class GuestListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GuestList()
        {
            return View() ;
        }
    }
}
