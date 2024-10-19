using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class GuestViewModel
    {
        public Guests ActiveGuest { get; set; }

        public Guests? PlusOne { get; set; }

        public List<WeddingParty> PartyRoles { get; set; }
    }
}
