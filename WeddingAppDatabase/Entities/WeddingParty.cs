using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class WeddingParty
    {
        [Key]
        public int PartyId { get; set; }

        public string? Role {  get; set; }

        public bool InWeddingParty { get; set; }

        public ICollection<Guests>? Guests { get; set; }
    }
}
