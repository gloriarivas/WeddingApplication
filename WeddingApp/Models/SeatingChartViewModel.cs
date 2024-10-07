using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class SeatingChartViewModel
    {
        public List<Tables> Tables { get; set; }
        public List<SeatingChart> Seats { get; set; }
    }
}
