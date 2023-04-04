using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Đồ_án_của_Thái.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public Comic Comic { get; set; }
        [Required]
        public int ComicId { get; set; }
        [Required]
        [StringLength(255)]
        public string PictureChap { get; set; }
    }
}