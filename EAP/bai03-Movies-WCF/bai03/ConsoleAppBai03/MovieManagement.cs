using ConsoleAppBai03.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBai03
{
    class MovieManagement
    {
        private MoviesServiceClient moviesServiceClient;
        public void InsertMovie()
        {

        }
        public void ShowAllMovies()
        {
            try
            {
                moviesServiceClient = new MoviesServiceClient();
                var movies = moviesServiceClient.GetAll();
                foreach (Movie movie in movies)
                {
                    Console.WriteLine(movie);
                }
                moviesServiceClient.Close();
            }
            catch (Exception e) {
                Console.WriteLine("Cannot get all movies");
            }
        }
        public void UpdateMovie()
        {

        }

    }
}
