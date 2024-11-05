using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        [HttpGet("/Seating")]
        public IActionResult GetSeatingChart()
        {
            List<SeatingChart> seats = _weddingDbContext.SeatingChart.ToList();
            List<Tables> tables = _weddingDbContext.Tables.ToList();
            SeatingChartViewModel seatingChart = new SeatingChartViewModel()
            {
                Seats = seats,
                Tables = tables
            };
            return View("SeatingChart");

        }
        [HttpGet()]
        public IActionResult AddNewTableRequest()
        {
            List<SeatingChart> seatingCharts = _weddingDbContext.SeatingChart.ToList();
            Tables table = new Tables();
            
            return View("AddTable", table);
        }
        // partial view link https://www.codeproject.com/Tips/5368991/NET-Core-7-Razor-pages-Updating-Section-of-a-Razor
    }

}
