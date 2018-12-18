using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmCuController : Controller
    {
        // GET: EmCu
        public ActionResult EnCuView()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int h = dt.Hour;

            //根据小时数判断需要返回哪个视图，小于12返回myview,大于返回yourview
            if (h < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            //获取或设置视图数据的字典
            //ViewData["greeting"] = greeting;
            ViewBag.greeting = greeting;



            Employee emp = new Employee();
            emp.Name = "潘水荣";
            emp.Salary = 5;

            Customer cu = new Customer();
            cu.CustomerName = "张三";
            cu.Address = "柳州";

            AddViewModel add = new AddViewModel();

            add.CustomerName = cu.CustomerName;
            add.CustomerAddress = cu.Address;

            add.EmployeeName = emp.Name;
            add.UserName = "管理员";

            add.EmployeeSalary = emp.Salary.ToString("C");
            if (emp.Salary > 1000)
            {
                add.EmployeeGrade = "土豪";
            }
            else
            {
                add.EmployeeGrade = "屌丝";
            }

            


            //ViewData["EmpKey"] = emp;
            //ViewBag.EmpKey = emp;
            return View("EnCuView", add);
        }
    }
}