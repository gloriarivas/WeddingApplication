using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class Restaurants
    {
        [Key]
        public int RestaurantId { get; set; }

        public string? RestaurantName { get; set; }

        public string? RestaurantDescription { get; set; }

        public string? CuisineType { get; set; }

        public int? DressCodeId { get; set; }
        public DressCode? DressCode { get; set; }

        public string? HoursBreakfast { get; set; }

        public string? HoursLunch { get; set; }

        public string? HoursDinner { get; set; }
    }
}
