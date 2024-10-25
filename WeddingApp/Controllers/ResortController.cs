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
            List<DressCode> dressCode = _weddingDbContext.DressCode.ToList();
            RestaurantViewModel restaurant = new RestaurantViewModel()
            {
                ActiveRestaurant = new Restaurants(),
                DressCodes = dressCode
            };
            return View("AddRestaurant", restaurant);
        }

        [HttpPost()]
        public IActionResult AddRestaurant(RestaurantViewModel viewModel)
        {
            //add am/pm to each dinner hours col
            AddRestaurantHours(viewModel);

            _weddingDbContext.Restaurants.Add(viewModel.ActiveRestaurant);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetResortInfo", "Resort");
        }

        [HttpGet("/EditRestaurant/{id}")]
        public IActionResult EditRestaurantRequest(int id)
        {
            Restaurants? restaurant = GetRestaurantById(id);
            List<DressCode> dressCode = _weddingDbContext.DressCode.ToList();
            RestaurantViewModel model = new RestaurantViewModel()
            {
                DressCodes = dressCode,
                ActiveRestaurant = restaurant
            };
            if (restaurant.HoursBreakfastStart != null)
            {
                model.HoursStartBreakfastAmPm = restaurant.HoursBreakfastStart.Substring(restaurant.HoursBreakfastStart.Length - 2);
                model.HoursEndBreakfastAmPm = restaurant.HoursBreakfastEnd.Substring(restaurant.HoursBreakfastEnd.Length - 2);
                model.HoursStartBreakfast = restaurant.HoursBreakfastStart.Substring(0, restaurant.HoursBreakfastStart.Length - 2);
                model.HoursEndBreakfast = restaurant.HoursBreakfastEnd.Substring(0, restaurant.HoursBreakfastEnd.Length - 2);
            }
            if (restaurant.HoursLunchStart != null)
            {
                model.HoursStartLunchAmPm = restaurant.HoursLunchStart.Substring(restaurant.HoursLunchStart.Length - 2);
                model.HoursEndLunchAmPm = restaurant.HoursLunchEnd.Substring(restaurant.HoursLunchEnd.Length - 2);
                model.HoursStartLunch = restaurant.HoursLunchStart.Substring(0, restaurant.HoursLunchStart.Length - 2);
                model.HoursEndLunch = restaurant.HoursLunchEnd.Substring(0, restaurant.HoursLunchEnd.Length - 2);
            }
            if (restaurant.HoursDinnerStart != null)
            {
                model.HoursStartDinnerAmPm = restaurant.HoursDinnerStart.Substring(restaurant.HoursDinnerStart.Length - 2);
                model.HoursEndDinnerAmPm = restaurant.HoursDinnerEnd.Substring(restaurant.HoursDinnerEnd.Length - 2);
                model.HoursStartDinner = restaurant.HoursDinnerStart.Substring(0, restaurant.HoursDinnerStart.Length - 2);
                model.HoursEndDinner = restaurant.HoursDinnerEnd.Substring(0, restaurant.HoursDinnerEnd.Length - 2);
            }
            
            return View("EditRestaurant", model);
        }

        [HttpPost()]
        public IActionResult EditRestaurant(RestaurantViewModel viewModel)
        {
            AddRestaurantHours(viewModel);
            _weddingDbContext.Restaurants.Update(viewModel.ActiveRestaurant);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetResortInfo", "Resort");
        }

        public IActionResult DeleteRestaurant(int restaurantId)
        {
            _weddingDbContext.Restaurants.Where(r => r.RestaurantId == restaurantId).ExecuteDelete();
           
            return RedirectToAction("GetResortInfo", "Resort");
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

        [HttpGet("/EditBar/{id}")]
        public IActionResult EditBarRequest(int id)
        {
            Bars? bar = GetBarById(id);
            BarViewModel barView = new BarViewModel()
            {
                ActiveBar = bar,
                HoursStartAmPm = bar.HoursStart.Substring(bar.HoursStart.Length - 2),
                HoursEndAmPm = bar.HoursEnd.Substring(bar.HoursEnd.Length - 2)
            };
            barView.ActiveBar.HoursStart = bar.HoursStart.Substring(0,bar.HoursStart.Length-2);
            barView.ActiveBar.HoursEnd = bar.HoursEnd.Substring(0,bar.HoursEnd.Length-2);
            return View("EditBar", barView);
        }


        [HttpPost()]
        public IActionResult EditBar(BarViewModel barViewModel)
        {
            barViewModel.ActiveBar.HoursStart += barViewModel.HoursStartAmPm;
            barViewModel.ActiveBar.HoursEnd += barViewModel.HoursEndAmPm;
            _weddingDbContext.Bars.Update(barViewModel.ActiveBar);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetResortInfo", "Resort");
        }

        public IActionResult DeleteBar(int barId)
        {
            _weddingDbContext.Bars.Where(b => b.BarId == barId).ExecuteDelete();
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
        private Bars? GetBarById(int id)
        {
            return _weddingDbContext.Bars.Where(b => b.BarId == id).FirstOrDefault();
        }
        private Restaurants? GetRestaurantById(int id)
        {
            return _weddingDbContext.Restaurants.Where(r => r.RestaurantId == id).FirstOrDefault();
        }

        private RestaurantViewModel? AddRestaurantHours(RestaurantViewModel viewModel)
        {
            if (viewModel.HoursStartBreakfast != null)
            {
                viewModel.ActiveRestaurant.HoursBreakfastStart = viewModel.HoursStartBreakfast + viewModel.HoursStartBreakfastAmPm;
                viewModel.ActiveRestaurant.HoursBreakfastEnd = viewModel.HoursEndBreakfast + viewModel.HoursEndBreakfastAmPm;
            }
            if (viewModel.HoursStartLunch != null)
            {
                viewModel.ActiveRestaurant.HoursLunchStart = viewModel.HoursStartLunch + viewModel.HoursStartLunchAmPm;
                viewModel.ActiveRestaurant.HoursLunchEnd = viewModel.HoursEndLunch + viewModel.HoursEndLunchAmPm;

            }
            if (viewModel.HoursStartDinner != null)
            {
                viewModel.ActiveRestaurant.HoursDinnerStart = viewModel.HoursStartDinner + viewModel.HoursStartDinnerAmPm;
                viewModel.ActiveRestaurant.HoursDinnerEnd = viewModel.HoursEndDinner + viewModel.HoursEndDinnerAmPm;
            }
            return viewModel;
        }
    }
}
