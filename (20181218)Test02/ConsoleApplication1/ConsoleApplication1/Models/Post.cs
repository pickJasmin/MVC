using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models
{
    /// <summary>
    /// 博文类
    /// </summary>
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //相当于数据库外码到作用
        public int BlogId { get; set; }
        //导航属性--目的是能够
        public virtual Blog Blog { get; set; }
    }
}
