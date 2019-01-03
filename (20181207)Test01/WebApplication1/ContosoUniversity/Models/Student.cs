using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {
        /// <summary>
        /// 学生类
        /// </summary>
        public int ID { get; set; }

        [Display(Name="姓名")]
        public string Name { get; set; }

        [Display(Name = "注册日期")]

        public DateTime EnrollmentDate { get; set; }//注册日期
        public virtual ICollection<Enrollment> Enrollments { get; set; }//导航属性
    }
}