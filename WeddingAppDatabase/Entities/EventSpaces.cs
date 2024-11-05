using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class EventSpaces
    {
        [Key]
        public int EventSpaceId { get; set; }

        public string? EventSpaceName { get; set; }

        public string? Description { get; set; }

        public int? MinGuests { get; set; }

        public int? MaxGuests { get; set;}

        public Double? BookingFee { get; set; }

        public bool? Favourite { get; set; } = false;

        public int? EventTypeId { get; set; }
        public EventTypes? EventType { get; set; }
    }
}
