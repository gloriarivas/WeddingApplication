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

        public string? HoursBreakfastStart { get; set; }
        public string? HoursBreakfastEnd { get; set; }

        public string? HoursLunchStart { get; set; }
        public string? HoursLunchEnd { get; set; }

        public string? HoursDinnerStart { get; set; }
        public string? HoursDinnerEnd { get; set; }
    }
}
