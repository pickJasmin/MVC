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
            
            //将处理过的数据列表送给强视图类型对象
            empListModel.EmployeeViewList = getEmpVmList();
            //获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }
        /// <summary>
        /// 跳转到新增页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        /// <summary>
        /// 添加数据到数据库中
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public ActionResult SaveEmployee(Employee emp)
        {
            EmployeeBusinessLayer eBL = new EmployeeBusinessLayer();
            eBL.AddSaveEmployee(emp);
            //跳转到index视图里
            return new RedirectResult("index");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteEmployee(int id)
        {
            

            EmployeeBusinessLayer eBL = new EmployeeBusinessLayer();
            eBL.DeleteSaveEmployee(id);
            //跳转到index视图里
            return new RedirectResult("/Employee/index");
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeBusinessLayer eBL = new EmployeeBusinessLayer();
            Employee emp = eBL.Query(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult UpdateSaveEmployee(Employee emp)
        {
            EmployeeBusinessLayer eBL = new EmployeeBusinessLayer();
            eBL.UpdateSaveEmployee(emp);
            return new RedirectResult("/Employee/index");
        }


        public ActionResult SelectEmployee(string name)
        {
            EmployeeBusinessLayer eBL = new EmployeeBusinessLayer();
            var queryList = eBL.QuerybyName(name);
            return View(queryList);
        }








        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        [NonAction]
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeesList();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            //通过循环遍历员工原始数据数组， 讲数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeID = item.EmployeeId;
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 1000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "穷人";
                }
                listEmpVm.Add(empVmObj);
            }
            return listEmpVm;
        }

        /// <summary>
        /// 问候语
        /// </summary>
        /// <returns></returns>
        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时
            int hour = dt.Hour;
            if (hour < 12)
            {
                greeting = "上午好！";
            }
            else
            {
                greeting = "下午好！";
            }
            return greeting;
        }
        /// <summary>
        /// 用户名
        /// </summary>
        /// <returns></returns>
        [NonAction]
        string getUserName()
        {
            return "管理员";
        }
    }
}