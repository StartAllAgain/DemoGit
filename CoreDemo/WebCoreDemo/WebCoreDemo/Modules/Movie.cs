using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreDemo.Modules
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name = "标题")]
        [StringLength(10, MinimumLength = 3)]
        public string Title { get; set; }
        [Display(Name = "发布时间")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "类型")]
        public string Genre { get; set; }
        [Display(Name = "价格")]

        public decimal Price { get; set; }
    }
}

