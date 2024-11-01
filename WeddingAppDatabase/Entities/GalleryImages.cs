using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class GalleryImages
    {
        [Key]
        public int PictureId { get; set; }

        public string? Url { get; set; }
    }
}
