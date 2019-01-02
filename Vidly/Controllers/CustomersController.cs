using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private DataContext _dataContext;
        public CustomersController()
        {
            _dataContext = new DataContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
        }
        public ActionResult Index()
        {
            var customers = _dataContext.Customers.ToList() ;
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            var customer = _dataContext.Customers.SingleOrDefault(c => c.Id == id); 
            if(customer == null ) return HttpNotFound();
            return View(customer);
        }
    }
}