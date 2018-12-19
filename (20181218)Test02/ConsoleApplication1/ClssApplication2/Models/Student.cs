using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClssApplication2.Models
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Sex { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
