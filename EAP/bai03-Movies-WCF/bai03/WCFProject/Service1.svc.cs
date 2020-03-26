using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public List<Movie> GetAll()
        {
            MoviesEntities entities = new MoviesEntities();
            List<Movie> movies = new List<Movie>();
            var movieListResult = from movie in entities.Movies select movie;
            foreach (var item in movieListResult)
            {
                Movie movie = new Movie();
                movie.MovieId = item.MovieId;
                movie.Title = item.Title;
                movie.ReleaseDate = item.ReleaseDate;
                movie.RunningTime = item.RunningTime;
                movie.GenreId = item.GenreId;
                movie.BoxOffice = item.BoxOffice;
                movies.Add(movie);
            }
            return movies;
        }


    }
}
