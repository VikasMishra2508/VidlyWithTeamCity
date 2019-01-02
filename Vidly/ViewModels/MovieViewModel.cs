using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        private List<Movie> _list;
        public MovieViewModel()
        {
            _list = new List<Movie>()
            {
                new Movie(){ Id =1, Name ="Hello!!"},
                new Movie(){ Id =2,Name = "3-Idiots"},
                new Movie(){ Id =3,Name = "Fun"},
                new Movie(){ Id =4,Name = "Hungama"}
            };
        }
        public List<Movie> Movies()
        {
            return _list;
        }
        
    }
}