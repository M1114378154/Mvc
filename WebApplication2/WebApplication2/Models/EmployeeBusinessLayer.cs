using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DataAccessLayer;

namespace WebApplication2.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL salesDal = new SalesERPDAL())
            {
            var list = salesDal.Employees.ToList();
            //return salesDal.Employees.ToList();
            return list;

            }
            
           
            //var list = new List<Employee>();

            //Employee emp = new Employee();
            //emp.Name = "杨";
            //emp.Salary = 15000;
            //list.Add(emp);

            //emp = new Employee();
            //emp.Name = "天";
            //emp.Salary = 2000;
            //list.Add(emp);

            //emp = new Employee();
            //emp.Name = "敏";
            //emp.Salary = 2500;
            //list.Add(emp);

            //return list;
        }
    }
}