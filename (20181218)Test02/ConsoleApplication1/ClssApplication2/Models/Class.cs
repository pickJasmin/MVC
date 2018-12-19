using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClssApplication2.Models
{
    /// <summary>
    /// 班级类
    /// </summary>
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        //导航属性--目的是通过班级对象访问对应到所在班级的学生
        public virtual List<Student> Students { get; set; }
    }
}
