using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class Dates
    {
        [Key]
        public int DateId { get; set; }

        public string Description { get; set; }

        //date and time the event starts
        public DateTime DateStart { get; set; }

        //date and time the event ends
        public DateTime DateEnd { get; set; }
    }
}
