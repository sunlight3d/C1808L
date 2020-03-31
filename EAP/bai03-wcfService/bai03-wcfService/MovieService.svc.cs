using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bai03_wcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovieService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MovieService.svc or MovieService.svc.cs at the Solution Explorer and start debugging.
    public class MovieService : IMovieService
    {
        private MoviesEntities db = new MoviesEntities();        
        public List<Movie> getAll()
        {
            try
            {
                return db.Movies.ToList();
            }
            catch (Exception e) {
                Console.WriteLine("Error getting Movies : {0}", e.ToString());
                return new List<Movie>();
            }            

        }
        public List<Movie> Search(String text)
        {
            try
            {
                var results = from movie in db.Movies
                              where movie.Title.Contains(text)
                              select movie;

                return results.ToList();                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting Movies : {0}", e.ToString());
                return new List<Movie>();
            }            
        }
        public void Add(Movie m) {
            try
            {
                db.Movies.Add(m);
                db.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error inserting Movies : {0}", e.ToString());
                
            }
            
        }
        public void Edit(Movie m)
        {
            try
            {                
                /*
                Movie foundMovie = db.Movies.FirstOrDefault(movie => movie.MovieId == m.MovieId);
                if (foundMovie != null) {
                    foundMovie.GenreId = m.GenreId;
                    foundMovie.Title = m.Title;
                    foundMovie.BoxOffice = m.BoxOffice;
                    foundMovie.RunningTime = m.RunningTime;
                    foundMovie.ReleaseDate = m.ReleaseDate;
                }*/
                db.Entry(m).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error inserting Movies : {0}", e.ToString());
                
            }

        }
        public void Delete(int id)
        {
            try
            {
                Movie foundMovie = db.Movies.Where(m => m.MovieId == id).FirstOrDefault();
                db.Entry(foundMovie).State = System.Data.Entity.EntityState.Deleted;
                //db.Movies.Remove(foundMovie);
                db.SaveChanges();                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error inserting Movies : {0}", e.ToString());                
            }

        }
    }
}
