using Microsoft.AspNetCore.Mvc;
using WeddingApp.DataAccess;
using WeddingApp.Models;
using WeddingAppDatabase.Entities;

namespace WeddingApp.Controllers
{
    public class ChecklistController : Controller
    {
        private WeddingDbContext _weddingDbContext;

        public ChecklistController(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checklist()
        {
            return View();
        }

        [HttpGet("/Checklist")]
        public IActionResult GetChecklist()
        {
            List<Checklists> checklist = _weddingDbContext.Checklists.ToList();
            ChecklistViewModel checklistView = new ChecklistViewModel()
            {
                ChecklistItems = checklist
            };
            return View("Checklist", checklistView);
        }

        [HttpPost()]
        public IActionResult AddNewItem(ChecklistViewModel checklistViewModel)
        {
            Checklists listItem = checklistViewModel.ListItem;
            if (listItem != null)
            {
                listItem.Completed = false;
                _weddingDbContext.Checklists.Add(listItem);
                _weddingDbContext.SaveChanges();
            }
            return RedirectToAction("GetChecklist", "Checklist");
        }
    }
}
