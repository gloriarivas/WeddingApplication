using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class EventSpaceViewModel
    {
        public EventSpaces? ActiveEventSpace { get; set; }

        public List<EventTypes> EventTypes { get; set; }
    }
}
