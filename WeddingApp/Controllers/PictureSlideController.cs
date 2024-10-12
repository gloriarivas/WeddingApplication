using Microsoft.AspNetCore.Mvc;
using WeddingApp.DataAccess;
using WeddingApp.Models;
using WeddingAppDatabase.Entities;

namespace WeddingApp.Controllers
{
    public class PictureSlideController : Controller
    {
        private WeddingDbContext _weddingDbContext;

        public PictureSlideController(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImages() {
            List<Pictures> pics = _weddingDbContext.Pictures.ToList();
            ImageViewModel imageViewModel = new ImageViewModel()
            {
                Pictures = pics
            };
            return View(imageViewModel);        
        }
    }
}
