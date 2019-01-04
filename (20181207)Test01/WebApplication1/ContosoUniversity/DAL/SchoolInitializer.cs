using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        /// <summary>
        /// Seed数据库初始化
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(SchoolContext context)
        {
            //构建学生数据
            var student = new List<Student> {
                new Student {Name="张三",EnrollmentDate=DateTime.Parse("2019-1-3")},
                new Student {Name="张死",EnrollmentDate=DateTime.Parse("2018-12-3")},
                new Student {Name="张三1",EnrollmentDate=DateTime.Parse("2019-11-2")},
                new Student {Name="张三2",EnrollmentDate=DateTime.Parse("2018-11-3")},
                new Student {Name="张三3",EnrollmentDate=DateTime.Parse("2018-11-3")},
                new Student {Name="张三4",EnrollmentDate=DateTime.Parse("2018-12-23")},
                new Student {Name="张三5",EnrollmentDate=DateTime.Parse("2018-12-13")},
                new Student {Name="张三6",EnrollmentDate=DateTime.Parse("2018-12-3")}


            };
            //将学生数据加入实体集(context上下文，名字由自己定义)
            student.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            //构建课程数据
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="C#程序设计",Credits=3,},
            new Course{CourseID=4022,Title="web开发",Credits=3,},
            new Course{CourseID=4041,Title="大学语文",Credits=3,},
            new Course{CourseID=1045,Title="大学英语",Credits=4,},
            new Course{CourseID=3141,Title="思想政治",Credits=4,},
            new Course{CourseID=2021,Title="心理健康",Credits=3,},
            new Course{CourseID=2042,Title="就业与创业",Credits=4,}
            };
            //将课程数据加入实体集
            courses.ForEach(cr => context.Courses.Add(cr));
            context.SaveChanges();


            //构建注册数据
            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            //将注册数据加入实体集
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}