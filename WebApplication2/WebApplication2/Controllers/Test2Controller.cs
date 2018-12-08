using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult CustomerView()
        {
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
            ViewBag.greeting = greeting;
            Customer cus = new Customer();
            cus.CustomerName = "张三";
            cus.Address = "柳州";
            ViewBag.CusKey = cus;
            return View(cus);
        }
    }
}