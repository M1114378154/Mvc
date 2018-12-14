using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CustomerBusinessLayer
    {
        public List<Customer> GetCustomer()
        {
            var listCus = new List<Customer>();

            Customer cus = new Customer();
            cus.CustomerName = "李四";
            cus.Address = "北京";
            listCus.Add(cus);

            cus = new Customer();
            cus.CustomerName = "王五";
            cus.Address = "天津";
            listCus.Add(cus);

            return listCus;
        }
    }
}