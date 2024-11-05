using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingApp.DataAccess;
using WeddingApp.Models;
using WeddingAppDatabase.Entities;

namespace WeddingApp.Controllers
{
    public class ImportantDatesController : Controller
    {
        private WeddingDbContext _weddingDbContext;

        public ImportantDatesController(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Dates")]
        public IActionResult GetDates(int orderBy)
        {
            List<Dates> dates = new List<Dates>();
            switch (orderBy)
            {
                case 0:
                    dates = _weddingDbContext.Dates.OrderBy(d => d.DateStart).ToList();
                    break;
                case 1:
                    dates = _weddingDbContext.Dates.OrderBy(d => d.DateName).ToList();
                    break;
                case 2:
                    dates = _weddingDbContext.Dates.OrderBy(d => d.DateEnd).ToList();
                    break;
                case 3:
                    dates = _weddingDbContext.Dates.OrderBy(d => d.Importance).ToList();
                    break;
            }

            DateViewModel dateViewModel = new DateViewModel()
            {
                Dates = dates
            };
            return View("ImportantDates", dateViewModel);
        }

        [HttpPost()]
        public IActionResult AddNewDate(DateViewModel viewModel)
        {
            _weddingDbContext.Dates.Add(viewModel.ActiveDate);
            _weddingDbContext.SaveChanges();

            return RedirectToAction("GetDates", "ImportantDates");
        }

        [HttpGet("EditEvent")]
        public IActionResult EditDateRequest(int dateId)
        {
            Dates dates = GetEventById(dateId);
            DateViewModel dateViewModel = new DateViewModel()
            {
                ActiveDate = dates
            };
            return View("EditEvent",dateViewModel);
        }

        [HttpPost()]
        public IActionResult EditDate(DateViewModel dateViewModel)
        {
            _weddingDbContext.Dates.Update(dateViewModel.ActiveDate);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetDates", "ImportantDates");
        }

        public IActionResult DeleteEvent(int dateId)
        {
            _weddingDbContext.Dates.Where(d => d.DateId == dateId).ExecuteDelete();
            return RedirectToAction("GetDates", "ImportantDates");
        }

        private Dates GetEventById(int eventId)
        {
            return _weddingDbContext.Dates.Where(d => d.DateId == eventId).FirstOrDefault();

        }
    }
}
