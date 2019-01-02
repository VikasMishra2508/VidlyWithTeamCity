using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public MovieCategory Category { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}