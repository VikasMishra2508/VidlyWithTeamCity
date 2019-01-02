using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name ="Honey I Shrunk The Kids!!!" };
            var customer = new List<Customer>()
            {
                new Customer(){ Name ="Customer-1"},
                new Customer(){ Name ="Customer-2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customer

            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }
        //movies
        public ActionResult Index()
        {

            var movies = new MovieViewModel().Movies().ToList();
            return View(movies);

        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            var movie = new MovieViewModel().Movies().Find(x => x.Id == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        [Route("movies/released/{year:regex(//d{4}):range(2001,2024)}/{month:regex(//d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,byte month)
        {
            return Content(year + "/" + month);
        }

}
}