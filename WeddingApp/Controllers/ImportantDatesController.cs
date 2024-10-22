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

        [HttpGet()]
        public IActionResult GetDates()
        {
            List<Dates> dates = _weddingDbContext.Dates.OrderBy(d => d.DateStart).ToList();
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
        public IActionResult EditDate(DateViewModel dateViewModel, int DateId)
        {
            dateViewModel.ActiveDate.DateId = DateId;
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
