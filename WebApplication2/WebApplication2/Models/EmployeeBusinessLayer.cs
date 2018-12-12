using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            var list = new List<Employee>();

            Employee emp = new Employee();
            emp.Name = "杨";
            emp.Salary = 15000;
            list.Add(emp);

            emp = new Employee();
            emp.Name = "天";
            emp.Salary = 2000;
            list.Add(emp);

            emp = new Employee();
            emp.Name = "敏";
            emp.Salary = 2500;
            list.Add(emp);

            return list;
        }
    }
}