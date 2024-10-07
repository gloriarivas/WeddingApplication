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

        [HttpGet()]
        public IActionResult AddNewGuestRequest()
        {
            return View("AddGuest");
        }

        [HttpPost("/AddGuest")]
        public IActionResult AddNewGuest(GuestViewModel guestViewModel)
        {

            _weddingDbContext.Guests.Add(guestViewModel.ActiveGuest);
            _weddingDbContext.SaveChanges();
            return View("GuestList");
        }

        [HttpGet("/GuestList")]
        public IActionResult GetGuestList()
        {
            List<Guests> guests = _weddingDbContext.Guests.OrderBy(g => g.LastName).ToList();
            GuestListViewModel guestList = new GuestListViewModel()
            {
                Guests = guests
            };

            return View("GuestList", guestList);
        }
    }
}
