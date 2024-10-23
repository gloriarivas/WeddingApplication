using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class RestaurantViewModel
    {
        public Restaurants? ActiveRestaurant { get; set; }

        public List<DressCode>? DressCodes { get; set; }

        public string? HoursStartBreakfast { get; set; }

        public string? HoursEndBreakfast { get; set; }

        public string? HoursStartBreakfastAmPm { get; set; }

        public string? HoursEndBreakfastAmPm { get; set; }

        public string? HoursStartLunch { get; set; }

        public string? HoursEndLunch { get; set; }

        public string? HoursStartLunchAmPm { get; set; }

        public string? HoursEndLunchAmPm { get; set; }

        public string? HoursStartDinner { get; set; }

        public string? HoursEndDinner { get; set; }

        public string? HoursStartDinnerAmPm { get; set; }

        public string? HoursEndDinnerAmPm { get; set; }
    }
}
