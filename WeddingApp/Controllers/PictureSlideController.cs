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

        [HttpGet("/Gallery")]
        public IActionResult GetImages() {
            //TODO: fix this
            List<Pictures> pics = _weddingDbContext.Pictures.ToList();
            //foreach (var picture in pics) {
            //    string url = Url.Action("getImage", "PictureSlide", new { path = picture.Url }, Request.Scheme);
            //    picture.Url = url;
            //}
            ImageViewModel imageViewModel = new ImageViewModel()
            {
                Pictures = pics
            };
            return View("PictureSlide",imageViewModel);        
        }

        private IActionResult getImage(string path)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);

            return File(imageBytes, "image/jpeg");
        }
    }
}
