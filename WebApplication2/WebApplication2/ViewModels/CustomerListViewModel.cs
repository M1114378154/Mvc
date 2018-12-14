using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class CustomerListViewModel
    {
        public string UserName{ get; set;}
        public string Greeting { get; set; }
        public List<CustomerViewModel> CustomerViewList { get; set; }
    }
}