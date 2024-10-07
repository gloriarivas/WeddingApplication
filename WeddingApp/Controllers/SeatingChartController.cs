using Microsoft.AspNetCore.Mvc;
using WeddingApp.DataAccess;
using WeddingApp.Models;
using WeddingAppDatabase.Entities;

namespace WeddingApp.Controllers
{

    public class SeatingChartController : Controller
    {
        private WeddingDbContext _weddingDbContext;
        public SeatingChartController(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSeatingChart()
        {
            List<SeatingChart> seats = _weddingDbContext.SeatingChart.ToList();
            List<Tables> tables = _weddingDbContext.Tables.ToList();
            SeatingChartViewModel seatingChart = new SeatingChartViewModel()
            {
                Seats = seats,
                Tables = tables
            };
            return View();

        }
    }
    
}
