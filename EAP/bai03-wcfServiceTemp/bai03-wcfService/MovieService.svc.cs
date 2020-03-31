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
        public List<Movie> getAll()
        {
            using (MoviesEntities db = new MoviesEntities())
            {

                db.Configuration.ProxyCreationEnabled = false;
                return db.Movies.ToList();                
            }
            
        }
        public List<Movie> Search(String text)
        {
            using (MoviesEntities db = new MoviesEntities())
            {

                db.Configuration.ProxyCreationEnabled = false;
                var results = from movie in db.Movies
                              where movie.Title.Contains(text)
                              select movie;
                
                return results.ToList();                
            }

            
        }
    }
}
