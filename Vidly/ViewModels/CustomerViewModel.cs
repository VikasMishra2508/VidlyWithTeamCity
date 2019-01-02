using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        private List<Customer> _list;
        public CustomerViewModel()
        {
            _list = new List<Customer>()
            {
                new Customer(){ Id=1, Name ="Vikas Mishra"},
                new Customer(){ Id=2, Name = "Zeba Ali"}
            };
        }
        public List<Customer> Customer()
        {
            return _list;
        }
    }
}