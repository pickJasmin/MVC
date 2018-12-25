using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        //员工信息业务层
        public List<Employee> GetEmployeesList()
        {
            //SalesERPDAL salesDal = new SalesERPDAL();
            //return salesDal.Employee.ToList();
            using(SalesERPDAL dal=new SalesERPDAL())
            {
                var list = dal.Employee.ToList();
                return list;
            }




            //List<Employee> employeesList = new List<Employee>();

            //Employee emp = new Employee();
            //emp.Name = "张三";
            //emp.Salary = 500;
            //employeesList.Add(emp);

            //emp = new Employee();
            //emp.Name = "张四";
            //emp.Salary = 1200;
            //employeesList.Add(emp);

            //emp = new Employee();
            //emp.Name = "李三";
            //emp.Salary = 1600;
            //employeesList.Add(emp);

            //return employeesList;
        }
    }
}