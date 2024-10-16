using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingApp.DataAccess;
using WeddingApp.Models;
using WeddingAppDatabase.Entities;

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
            List<Restaurants> restaurants = _weddingDbContext.Restaurants.Include(r => r.DressCode).ToList();
            List<Bars> bars = _weddingDbContext.Bars.ToList();
            List<DressCode> dressCode = _weddingDbContext.DressCode.ToList();
            ResortInfoViewModel resortInfoViewModel = new ResortInfoViewModel()
            {
                Restaurants = restaurants,
                Bars = bars,
                DressCodes = dressCode
            };

            return View("Resort", resortInfoViewModel);
        }
    }
}
