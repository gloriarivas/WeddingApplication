using Microsoft.AspNetCore.Mvc;
using WeddingApp.DataAccess;
using WeddingApp.Models;
using WeddingAppDatabase.Entities;

namespace WeddingApp.Controllers
{
    public class GuestListController : Controller
    {
        //instance of DB
        private WeddingDbContext _weddingDbContext;
        public GuestListController(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GuestList()
        {
            return View() ;
        }

        /// <summary>
        /// Get req for add guest, goes to a blank add page
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult AddNewGuestRequest()
        {
            return View("AddGuest");
        }

        /// <summary>
        /// Post from add guest page, adds new guest to the db and returns the new list of guests
        /// </summary>
        /// <param name="guestViewModel"></param>
        /// <returns></returns>
        [HttpPost("/AddGuest")]
        public IActionResult AddNewGuest(GuestViewModel guestViewModel)
        {

            _weddingDbContext.Guests.Add(guestViewModel.ActiveGuest);
            _weddingDbContext.SaveChanges();
            return RedirectToAction("GetGuestList", "GuestList");
        }

        /// <summary>
        /// get req for guest list, outputs the list of guests in order by last name
        /// </summary>
        /// <returns></returns>
        [HttpGet("/GuestList")]
        public IActionResult GetGuestList()
        {
            List<Guests> guests = _weddingDbContext.Guests.OrderBy(g => g.LastName).ToList();
            //turn the list into the view model then pass to the cshtml page
            GuestListViewModel guestList = new GuestListViewModel()
            {
                Guests = guests
            };

            return View("GuestList", guestList);
        }

        /// <summary>
        /// Get req for edit, takes the guest id and outputs the guest info into a form, can make edits
        /// </summary>
        /// <param name="guestId"></param>
        /// <returns></returns>
        [HttpGet("/EditGuest/{guestId}")]
        public IActionResult EditGuestRequest(int guestId)
        {

            return View();
        }
    }
}
