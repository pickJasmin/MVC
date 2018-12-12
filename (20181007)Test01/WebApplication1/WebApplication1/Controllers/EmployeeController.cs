using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            

            //实例化员工信息业务层
            EmployeeBusinessLayer empPL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empPL.GetEmployeesList();
            //员工原始数据加工后的视图数据列表，当前状态为空
            var listEmpVm = new List<EmployeeViewModel>();
            //通过循环遍历员工原始数据数组，将数据一个个转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 1000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "屌丝";

                }
                listEmpVm.Add(empVmObj);
            }


            //将处理过的数据列表送给强视图类型对象
            empListModel.EmployeeList = listEmpVm;





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
            empListModel.Greeting = greeting;
            empListModel.UserName = "管理员";
            return View(empListModel);
        }
    }
}