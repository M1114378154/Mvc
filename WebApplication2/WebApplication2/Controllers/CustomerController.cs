using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ViewModels;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerListViewModel cusListModel = new CustomerListViewModel();

            CustomerBusinessLayer cusBL = new CustomerBusinessLayer();
            var listCus = cusBL.GetCustomer();
            var listCusVm = new List<CustomerViewModel>();

            foreach (var item in listCus)
            {
                CustomerViewModel cusVmObj = new CustomerViewModel();
                cusVmObj.CustomerName = item.CustomerName;
                cusVmObj.Address = item.Address;

                listCusVm.Add(cusVmObj);
            }
            cusListModel.CustomerViewList = listCusVm;

            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时
            int hour = dt.Hour;
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "中午好";
            }

            cusListModel.Greeting = greeting;
            cusListModel.UserName = "超级管理员";

            return View(cusListModel);
        }
    }
}