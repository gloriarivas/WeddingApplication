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

        /// <summary>
        /// Returns the checklist items, ordered by completed boolean
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Checklist")]
        public IActionResult GetChecklist()
        {
            //order: checked items on the bottom
            List<Checklists> checklist = _weddingDbContext.Checklists.OrderBy(c => c.Completed).ToList();
            List<PackingList> packingList = _weddingDbContext.PackingList.OrderBy(p => p.IsPacked).ToList();
            ChecklistViewModel checklistView = new ChecklistViewModel()
            {
                ChecklistItems = checklist,
                PackingItems = packingList
            };
            return View("Checklist", checklistView);
        }

        /// <summary>
        /// Adds the new checklist item to the db, then returns to the checklist page (refreshed)
        /// </summary>
        /// <param name="checklistViewModel"></param>
        /// <returns></returns>
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

        [HttpPost()]
        public IActionResult AddNewPackingItem(ChecklistViewModel checklistViewModel)
        {
            PackingList packedItem = checklistViewModel.PackedItem;
            if (packedItem != null)
            {
                packedItem.IsPacked = false;
                packedItem.IsPurchased = false;
                _weddingDbContext.PackingList.Add(packedItem);
                _weddingDbContext.SaveChanges();
            }
            return RedirectToAction("GetChecklist", "Checklist");
        }

        /// <summary>
        /// update the database tp display the item as checked, reload the page so checked items are below
        /// </summary>
        /// <param name="checklistId"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CheckItem(int checklistId)
        {
            Checklists? item = _weddingDbContext.Checklists.Where(l => l.ChecklistId == checklistId).FirstOrDefault();
            if (!item.Completed && item != null)
            {
                item.Completed = true;
            }
            else
            {
                item.Completed = false;
            }
            _weddingDbContext.Checklists.Update(item);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetChecklist", "Checklist");
        }

        [HttpPost()]
        public IActionResult CheckedPackedList(int packingListId)
        {   
            PackingList? item = _weddingDbContext.PackingList.Where(l => l.PackingListId == packingListId).FirstOrDefault();
            if (!item.IsPacked)
            {
                item.IsPacked = true;
            }
            else
            {
                item.IsPacked = false;
            }
            _weddingDbContext.PackingList.Update(item);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetChecklist", "Checklist");
        }
    }
}
