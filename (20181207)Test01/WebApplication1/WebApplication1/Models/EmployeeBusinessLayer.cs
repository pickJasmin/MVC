using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (SalesERPDAL dal = new SalesERPDAL())
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

        //新增
        public void AddSaveEmployee(Employee emp)
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
                //将给定实体以“已添加”状态添加到集的基础上下文中，这样一来，当调用 SaveChanges 时，会将该实体插入到数据库中。
                dal.Employee.Add(emp);
                //将所有更新保存至dal（将在此上下文中所做的所有更改保存到基础数据库。）
                dal.SaveChanges();
            }
        }


        
        //删除
        public void DeleteSaveEmployee(int id)
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
                Employee emp = dal.Employee.Find(id);
                dal.Entry(emp).State = EntityState.Deleted;
                dal.SaveChanges();
            }
        }

        public Employee Query(int id)
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
                return dal.Employee.Find(id);
            }
        }

        //更新
        public void UpdateSaveEmployee(Employee emp)
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
                
                dal.Entry(emp).State = EntityState.Modified;
                dal.SaveChanges();

            }
        }
    }
}