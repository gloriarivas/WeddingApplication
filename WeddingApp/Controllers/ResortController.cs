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

        [HttpGet("/NewRestaurant")]
        public IActionResult AddRestaurantRequest()
        {
            return View();
        }

        [HttpGet("/AddNewBar")]
        public IActionResult AddBarRequest()
        {
            BarViewModel bar = new BarViewModel()
            {
                ActiveBar = new Bars()
            };
            return View("AddBar", bar);
        }

        [HttpPost()]
        public IActionResult AddBar(BarViewModel barViewModel)
        {
            //add am and pm
            barViewModel.ActiveBar.HoursStart += barViewModel.HoursStartAmPm;
            barViewModel.ActiveBar.HoursEnd += barViewModel.HoursEndAmPm;
            _weddingDbContext.Bars.Add(barViewModel.ActiveBar);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetResortInfo", "Resort");
        }

        [HttpGet("/AddDressCode")]
        public IActionResult AddDressCodeRequest()
        {
            DressCodeViewModel dressCode = new DressCodeViewModel()
            {
                ActiveDressCode = new DressCode()
            };
            return View("AddDressCode",dressCode);
        }

        [HttpPost()]
        public IActionResult AddDressCode(DressCodeViewModel dressCode)
        {
            _weddingDbContext.DressCode.Add(dressCode.ActiveDressCode);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetResortInfo", "Resort");
        }

        [HttpGet("/EditDressCode/{dressCodeId}")]
        public IActionResult EditDressCodeRequest(int dressCodeId)
        {
            DressCodeViewModel dressCode = new DressCodeViewModel()
            {
                ActiveDressCode = GetDressCodeById(dressCodeId)
            };
            return View("EditDressCode", dressCode);
        }

        [HttpPost()]
        public IActionResult EditDressCode(DressCodeViewModel dressCodeModel, int dressCodeId)
        {
            dressCodeModel.ActiveDressCode.DressCodeId = dressCodeId;
            _weddingDbContext.DressCode.Update(dressCodeModel.ActiveDressCode);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetResortInfo", "Resort");
        }

        private DressCode? GetDressCodeById(int dressCodeId)
        {
            return _weddingDbContext.DressCode.Where(d => d.DressCodeId == dressCodeId).FirstOrDefault();
        }
    }
}
