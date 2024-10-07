using Microsoft.AspNetCore.Mvc;

namespace WeddingApp.Controllers
{
    public class SeatingChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
