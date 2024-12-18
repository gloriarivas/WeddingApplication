﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class PackingList
    {
        [Key]
        public int PackingListId { get; set; }

        public string? ListItem { get; set; }

        public bool IsPacked { get; set; }

        public bool IsPurchased { get; set; }
    }
}
