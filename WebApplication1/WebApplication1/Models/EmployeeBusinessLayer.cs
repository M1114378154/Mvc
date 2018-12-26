﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;
using System.Data.Entity;


namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            //实例化上下文
            using (SalesERPDAL dal = new SalesERPDAL())
            {
              
                var list = dal.Employees.ToList();
                return list;
            }   
        }
        public void AddEmp(Employee e)
        {
            using(var db= new SalesERPDAL())
            {
                db.Employees.Add(e);
                db.SaveChanges();
            }
        }
        public void DeleteEmployee(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                db.Entry(emp).State = EntityState.Deleted;
                db.SaveChanges();
            }

        }



    }
}