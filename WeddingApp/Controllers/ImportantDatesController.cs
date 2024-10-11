using Microsoft.AspNetCore.Mvc;
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
        //[HttpGet("/Checklist")]
        //public IActionResult GetChecklist()
        //{
        //    //order: checked items on the bottom
        //    List<Checklists> checklist = _weddingDbContext.Checklists.OrderBy(c => c.Completed).ToList();
        //    ChecklistViewModel checklistView = new ChecklistViewModel()
        //    {
        //        ChecklistItems = checklist
        //    };
        //    return View("Checklist", checklistView);
        //}
    }
}
