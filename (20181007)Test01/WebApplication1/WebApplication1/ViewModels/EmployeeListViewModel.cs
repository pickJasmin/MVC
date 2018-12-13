using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class EmployeeListViewModel
    {
        //管理员
        public string UserName { get; set; }
        //问候语
        public string Greeting { get; set; }
        public List<EmployeeViewModel> EmployeeViewList { get; set; }
    }
}