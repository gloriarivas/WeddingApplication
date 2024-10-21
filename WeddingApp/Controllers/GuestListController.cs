using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            return View();
        }

        /// <summary>
        /// Get req for add guest, goes to a blank add page
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult AddNewGuestRequest()
        {
            List<WeddingParty> parties = _weddingDbContext.WeddingParties.ToList();
            GuestViewModel model = new GuestViewModel()
            {
                ActiveGuest = new Guests(),
                PlusOne = new Guests(),
                PartyRoles = parties
            };
                
            return View("AddGuest", model);
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
            if (guestViewModel.PlusOne.FirstName != null) //add plus one and add the ids in Plus One table to match with their guest
            {
                _weddingDbContext.Guests.Add(guestViewModel.PlusOne);
                _weddingDbContext.SaveChanges();
                Guests? guest = AddPlusOne(guestViewModel.ActiveGuest.FirstName, guestViewModel.ActiveGuest.LastName);
                Guests? plusOne = AddPlusOne(guestViewModel.PlusOne.FirstName, guestViewModel.PlusOne.LastName);
                PlusOnes plusOneRelationship = new PlusOnes()
                {
                    InvitedGuestId = guestViewModel.ActiveGuest.GuestId,
                    PlusOneId = guestViewModel.PlusOne.GuestId
                };
                _weddingDbContext.PlusOnes.Add(plusOneRelationship);
            }

            _weddingDbContext.SaveChanges();

            return RedirectToAction("GetGuestList", "GuestList");
        }


        /// <summary>
        /// get req for guest list, outputs the list of guests
        /// </summary>
        /// <returns></returns>
        [HttpGet("/GuestList")]
        public IActionResult GetGuestList(int orderBy)
        {
            List<Guests> guests = new List<Guests>();
            switch (orderBy)
            {
                case 0: //inital
                    guests = _weddingDbContext.Guests.Include(w => w.WeddingParty).ToList();
                    break;
                case 1: //order by first name
                    guests = _weddingDbContext.Guests.Include(w => w.WeddingParty).OrderBy(w => w.FirstName).ToList();
                    break;
                case 2: //order by last name
                    guests = _weddingDbContext.Guests.Include(w => w.WeddingParty).OrderBy(w => w.LastName).ToList();
                    break;
                case 3: //order by role
                    guests = _weddingDbContext.Guests.Include(w => w.WeddingParty).OrderBy(w => w.WeddingPartyId).ToList();
                    break;
            }
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
            List<WeddingParty> parties = _weddingDbContext.WeddingParties.ToList();
            List<Guests> guests = GetGuestById(guestId);

            GuestViewModel guest = new GuestViewModel()
            {
                ActiveGuest = guests[0],
                PlusOne = guests[1],
                PartyRoles = parties
            };
            return View("EditGuest", guest);
        }

        /// <summary>
        /// Update guest info to db, then redirect to the guest list
        /// </summary>
        /// <param name="guestViewModel"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult EditGuest(GuestViewModel guestViewModel, int guestId, int plusOneId)
        {
            //for some reason view model isn't passing the id, so re-add it before updating db
            guestViewModel.ActiveGuest.GuestId = guestId;
            _weddingDbContext.Guests.Update(guestViewModel.ActiveGuest);
            if (plusOneId != 0)
            {
                guestViewModel.PlusOne.GuestId = plusOneId;
                _weddingDbContext.Guests.Update(guestViewModel.PlusOne);
            }
            _weddingDbContext.SaveChanges();

            return RedirectToAction("GetGuestList", "GuestList");
        }
        //TODO: delete guest button funcs, add plus ones

        /// <summary>
        /// Deletes the guest with guest id, redirects to the guest list page
        /// </summary>
        /// <param name="guestId"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult DeleteGuestRequest(int guestId) 
        {
            _weddingDbContext.Guests.Where(g => g.GuestId == guestId).ExecuteDelete();
            return RedirectToAction("GetGuestList", "GuestList");
        }

        private List<Guests>? GetGuestById(int guestId)
        {
            List<Guests> guests = new List<Guests>();

            //check if guest is invited guest or a plus one
            PlusOnes plusOne = _weddingDbContext?.PlusOnes.Where(p => p.InvitedGuestId == guestId).FirstOrDefault();

            if (_weddingDbContext?.PlusOnes.Where(p => p.InvitedGuestId == guestId).FirstOrDefault() == null)
            {
                plusOne = _weddingDbContext?.PlusOnes.Where(p => p.PlusOneId == guestId).FirstOrDefault();
                
            }
            guests.Add(_weddingDbContext?.Guests.Where(g => g.GuestId == plusOne.InvitedGuestId).FirstOrDefault());
            guests.Add(_weddingDbContext?.Guests.Where(g => g.GuestId == plusOne.PlusOneId).FirstOrDefault());
            return guests;
        }
        private Guests AddPlusOne(string guestName, string lastName)
        {
            return _weddingDbContext?.Guests.Where(g => g.FirstName == guestName).Where(g => g.LastName == lastName).FirstOrDefault();
        }

    }
}
