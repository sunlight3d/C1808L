using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace bai03
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MoviesInterfaceImplementation : IMoviesInterface
    {
        public void Add(Movie m)
        {
            try
            {
                using (MoviesEntities entities = new MoviesEntities())
                {
                    entities.Movies.Add(m);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cannot add movie:" + exception.ToString());
            }
        }

        public void Delete(int Id)
        {
            if (Id <= 0)
            {
                Console.WriteLine("Id is invalid(must be > 0)");
            }
            try
            {
                using (MoviesEntities entities = new MoviesEntities())
                {
                    Movie foundMovie = entities.Movies.FirstOrDefault(movie => movie.MovieId == Id);
                    if (foundMovie != null)
                    {
                        entities.Entry(foundMovie).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Cannot find movie to delete");
                    }
                }
            }
            catch (Exception exception)

            {
                Console.WriteLine("Cannot update movie:" + exception.ToString());
            }
        }

        public void Edit(Movie m)
        {
            try
            {
                using (MoviesEntities entities = new MoviesEntities())
                {
                    Movie foundMovie = entities.Movies.FirstOrDefault(movie => movie.MovieId == m.MovieId);
                    if (foundMovie != null)
                    {
                        foundMovie.Title = m.Title;
                        foundMovie.ReleaseDate = m.ReleaseDate;
                        foundMovie.RunningTime = m.RunningTime;
                        foundMovie.GenreId = m.GenreId;
                        foundMovie.BoxOffice = m.BoxOffice;
                        entities.SaveChanges();
                    }
                    else {
                        Console.WriteLine("Cannot find movie to update");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cannot update movie:" + exception.ToString());
            }
        }

        public List<Movie> GetAll()
        {
            using (MoviesEntities entities = new MoviesEntities())
            {
                
                List<Movie> movies = entities.Movies.ToList();
                return movies.ToList();
            }
        }

        public Movie GetById(int Id)
        {
            try
            {
                using (MoviesEntities entities = new MoviesEntities())
                {
                    Movie foundMovie = entities.Movies.FirstOrDefault(movie => movie.MovieId == Id);
                    return foundMovie;                    
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cannot get movie's information:" + exception.ToString());
                return null;
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Movie> Search(string Title)
        {
            try {
                using (MoviesEntities entities = new MoviesEntities())
                {
                    List<Movie> foundMovies = entities.Movies.Where(movie => movie.Title == Title).ToList();
                    return foundMovies;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cannot get movie's information:" + exception.ToString());
                return new List<Movie>();
            }
            
        }
    }
}
