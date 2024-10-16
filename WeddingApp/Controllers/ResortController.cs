using Microsoft.AspNetCore.Mvc;
using WeddingApp.DataAccess;

namespace WeddingApp.Controllers
{
    public class ResortController : Controller
    {
        private WeddingDbContext _weddingDbContext;
        public ResortController(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Resort")]
        public IActionResult GetResortInfo()
        {
            return View("Resort");
        }
    }
}
