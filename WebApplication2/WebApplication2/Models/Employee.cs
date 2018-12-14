using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Key]
        public string Name { get; set; }
        public int Salary { get; set; }
       
    }
}