using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class Checklists
    {
        [Key]
        public int ChecklistId { get; set; }

        public string? ListItem { get; set; }

        public bool Completed { get; set; }
    }
}
