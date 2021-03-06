﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "Hello!MVC!";
        }
        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "hao";
            ct.Address = "rnrnr";
            return ct;
        }

        public ActionResult GetView()
        {
            //string greeting;
            ////获取当前时间
            //DateTime dt = DateTime.Now;
            ////获取当前小时数
            //int h = dt.Hour;

            ////根据小时数判断需要返回哪个视图，小于12返回myview,大于返回yourview
            //if (h < 12)
            //{
            //    greeting = "早上好";
            //}
            //else
            //{
            //    greeting = "下午好";
            //}
            //获取或设置视图数据的字典
            //ViewData["greeting"] = greeting;
            //ViewBag.greeting = greeting;

            Employee emp = new Employee();
            emp.Name = "潘水荣";
            emp.Salary = 5;

            EmployeeViewModel empM = new EmployeeViewModel();
            empM.EmployeeName = emp.Name;
            //empM.UserName = "管理员";

            empM.EmployeeSalary = emp.Salary.ToString("C");
            if (emp.Salary > 1000)
            {
                empM.EmployeeGrade = "土豪";
            }
            else
            {
                empM.EmployeeGrade = "屌丝";
            }



            //ViewData["EmpKey"] = emp;
            //ViewBag.EmpKey = emp;
            return View("MyView", empM);

        }
    }
}