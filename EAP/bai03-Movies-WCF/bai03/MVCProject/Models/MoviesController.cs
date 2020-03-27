using MVCProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Models
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            Service1Client client = new Service1Client();
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach(var item in client.GetAll())
            {
                MovieModel movieModel = new MovieModel();
                movieModel.Title = item.Title;
                movieModel.GenreId = item.GenreId;
                movieModel.RunningTime = item.RunningTime;
                movieModel.BoxOffice = item.BoxOffice;
            }
            return View(movieModels);
        }
        public ActionResult Details(int id)
        {
            Service1Client client = new Service1Client();
            var selectedMovie = client.GetById(id);
            if (selectedMovie == null)
            {
                return HttpNotFound();
            }

            MovieModel movieModel = new MovieModel();
            movieModel.GenreId = selectedMovie.GenreId;
            movieModel.ReleaseDate = selectedMovie.ReleaseDate;
            movieModel.Title = selectedMovie.Title;
            movieModel.RunningTime = selectedMovie.RunningTime;
            movieModel.BoxOffice = selectedMovie.BoxOffice;            
            return View(movieModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MovieModel newMovieModel)
        {
            Service1Client client = new Service1Client();
            MovieModel movieModel = new MovieModel();

            movieModel.GenreId = newMovieModel.GenreId;
            movieModel.ReleaseDate = newMovieModel.ReleaseDate;
            movieModel.Title = newMovieModel.Title;
            movieModel.RunningTime = newMovieModel.RunningTime;
            movieModel.BoxOffice = newMovieModel.BoxOffice;
            //client.Add(newMovieModel);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Service1Client client = new Service1Client();
            client.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(MovieModel updatedMovieModel)
        {
            MovieModel movieModel = new MovieModel();
            
            movieModel.GenreId = updatedMovieModel.GenreId;
            movieModel.ReleaseDate = updatedMovieModel.ReleaseDate;
            movieModel.Title = updatedMovieModel.Title;
            movieModel.RunningTime = updatedMovieModel.RunningTime;
            movieModel.BoxOffice = updatedMovieModel.BoxOffice;

            Service1Client client = new Service1Client();
            return RedirectToAction("Index");
            
            return View();
        }
    }

}