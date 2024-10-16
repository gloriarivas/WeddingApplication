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

        public double? HoursStart { get; set; }

        public double? HoursEnd { get; set; }

        public bool HasBreakfastHours { get; set; }

        public double? BreakfastHoursStart { get; set; }

        public double? BreakfastHoursEnd { get;set; }
    }
}
