using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "Hello! MVC~";
        }
        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "aaa";
            ct.Address = "mvc";
            return ct;
        }
        public ActionResult GetView()
        {
            //获取当前时间
            //获取当前小时数
            //根据小时数判断需要返回那个视图,<12 返回myview 否则返回yourview>
            //int h = 0;
            //h = DateTime.Now.Hour;
            //if (h < 12)
            //{
            //    return View("MyView");
            //}
            //else
            //{
            //    return View("YourView");
            //}

            string greeting;
            DateTime dt = DateTime.Now;
            int hour = dt.Hour;
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "中午好";
            }
           ViewData["greeting"] = greeting;
            //ViewBag.greeting= greeting;
            Employee emp = new Employee();
            emp.Name = "李四";
            emp.Salary = 15000;
            EmployeeViewModel vmEmp = new EmployeeViewModel();
            vmEmp.EmployeeName = emp.Name;
            vmEmp.EmployeeSalary = emp.Salary.ToString("C");
            if (emp.Salary > 1000)
            {
                vmEmp.EmployeeGrade = "土豪";
            }
            else
            {
                vmEmp.EmployeeGrade = "土鳖";
            }

            //ViewData["EmpKey"] = emp;
            //ViewBag.EmpKey = emp;
            vmEmp.UserName = "管理员";
            return View(vmEmp);

        }
    }
}