using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// 注册类
    /// </summary>
    public enum Grade
    {
        //优、良、
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }//等级

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}