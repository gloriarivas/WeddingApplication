using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class BarViewModel
    {
        public Bars? ActiveBar { get; set; }

        public string? HoursStartAmPm { get; set; }

        public string? HoursEndAmPm { get; set; }
    }
}
