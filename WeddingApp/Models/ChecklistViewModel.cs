using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class ChecklistViewModel
    {
        public Checklists? ListItem { get; set; }
        public List<Checklists> ChecklistItems { get; set; }
    }
}
