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
            return RedirectToAction("GetGuestList", "GuestList");
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
                PartyRoles = parties
            };
            if (guests.Count >= 2)
            {
                guest.PlusOne = guests[1];
            }
            return View("EditGuest", guest);
        }

        /// <summary>
        /// Update guest info to db, then redirect to the guest list
        /// </summary>
        /// <param name="guestViewModel"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult EditGuest(GuestViewModel guestViewModel)
        {
            
            _weddingDbContext.Guests.Update(guestViewModel.ActiveGuest);
            if (guestViewModel.PlusOne.GuestId != 0)
            {
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
            //first need to delete any link to PlusOnes table, if guest that is being deleted is a plus one, then just delete them, else delete both guests
            List<Guests> guests = GetGuestById(guestId);
            if (guests.Count >= 2)
            {
                _weddingDbContext.PlusOnes.Where(g => g.InvitedGuestId == guests[0].GuestId).ExecuteDelete();
                if (guestId == guests[0].GuestId) //if guest is the plus one, just delete the relationship and the guest
                {
                    _weddingDbContext.Guests.Where(g => g.GuestId == guests[0].GuestId).ExecuteDelete();
                }
                _weddingDbContext.Guests.Where(g => g.GuestId == guests[1].GuestId).ExecuteDelete();
                return RedirectToAction("GetGuestList", "GuestList");
            }
            _weddingDbContext.Guests.Where(g => g.GuestId == guestId).ExecuteDelete();
            return RedirectToAction("GetGuestList", "GuestList");
        }

        private List<Guests>? GetGuestById(int guestId)
        {
            List<Guests> guests = new List<Guests>();

            //check if guest is invited guest or a plus one
            PlusOnes invited = _weddingDbContext?.PlusOnes.Where(p => p.InvitedGuestId == guestId).FirstOrDefault();
            PlusOnes plusOne = _weddingDbContext?.PlusOnes.Where(p => p.PlusOneId == guestId).FirstOrDefault();

            if (invited == null && plusOne == null) //if not in table at all, then guest does not have a plus one
            {
                guests.Add(_weddingDbContext?.Guests.Where(g => g.GuestId == guestId).FirstOrDefault());
                return guests;
            }
            if (invited != null)
            {
                guests.Add(_weddingDbContext?.Guests.Where(g => g.GuestId == invited.InvitedGuestId).FirstOrDefault());
                guests.Add(_weddingDbContext?.Guests.Where(g => g.GuestId == invited.PlusOneId).FirstOrDefault());
                return guests;
                
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
