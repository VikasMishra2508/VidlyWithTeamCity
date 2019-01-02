using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("name=DefCon")
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
    }
}