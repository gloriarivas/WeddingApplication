using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class PlusOnes
    {
        [Key]
        public int Id { get; set; } 

        public int? InvitedGuestId { get; set; }
        public Guests? InvitedGuest { get; set; }

        public int? PlusOneId { get; set; }
        public Guests? PlusOne { get; set; }
    }
}
