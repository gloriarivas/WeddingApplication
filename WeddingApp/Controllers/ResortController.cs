﻿using Microsoft.AspNetCore.Mvc;
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

            _weddingDbContext.Restaurants.Add(viewModel.ActiveRestaurant);
            _weddingDbContext.SaveChanges();
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
        public IActionResult EditBar(BarViewModel barViewModel, int barId)
        {
            barViewModel.ActiveBar.BarId = barId;
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
    }
}
