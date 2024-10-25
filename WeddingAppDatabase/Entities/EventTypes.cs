using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class EventTypes
    {
        [Key]
        public int EventTypeId { get; set; }

        public string TypeName { get; set; }

        public ICollection<EventSpaces>? EventSpaces  { get; set; }
    }
}
