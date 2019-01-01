using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        //标题
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        //发布日期
        public DateTime ReleaseDate { get; set; }
        //类型电影”(Genre Film),
        public string Genre { get; set; }
        //价格；价值；代价
        public decimal Price { get; set; }
    }
}