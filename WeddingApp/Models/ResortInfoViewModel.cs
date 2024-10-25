using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class ResortInfoViewModel
    {
        public List<Restaurants>? Restaurants { get; set; }

        public List<Bars>? Bars { get; set; }

        public List<DressCode>? DressCodes { get; set; }

        public List<EventSpaces>? EventSpaces { get; set; }
    }
}
