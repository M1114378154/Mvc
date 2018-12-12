using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class LayerController : Controller
    {
        // GET: Layer
        public ActionResult LayerView()
        {
           EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.Name = "张三";
            //vmEmp.Salary = 1500;
            //vmEmp.CustomerName = "李四";
            //vmEmp.Address = "柳州";
            return View(vmEmp);

        }
    }
}