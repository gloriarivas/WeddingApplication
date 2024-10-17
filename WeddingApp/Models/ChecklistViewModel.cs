using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class ChecklistViewModel
    {
        public Checklists? ListItem { get; set; }

        public List<Checklists> ChecklistItems { get; set; }

        public List<PackingList> PackingItems { get; set; }

        public PackingList? PackedItem { get; set; }
    }
}
