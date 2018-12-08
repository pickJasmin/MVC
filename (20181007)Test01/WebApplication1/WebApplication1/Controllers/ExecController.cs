using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ExecController : Controller
    {
        // GET: Exec
        public ActionResult IndexView()
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
            Customer cu = new Customer();

            ViewData["EmpKey"] = emp;
            ViewData["CuKey"] = cu;
            //ViewBag.CusKey = cu;

            emp.Name = "潘水荣";
            emp.Salary = 5;
            

            cu.CustomerName = "张三";
            cu.Address = "柳州";



            return View("IndexView");

        }
    }
}