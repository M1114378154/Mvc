using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

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
            Employee emp = new Employee();
            emp.Name = "李四";
            emp.Salary = 2002;
            ViewData["EmpKey"] = emp;
            return View("MyView");
        }
    }
}