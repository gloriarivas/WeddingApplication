using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class DateViewModel
    {
        public List<Dates>? Dates { get; set; }

        public Dates? ActiveDate { get; set; }
    }
}
