using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFConsoleApp.MovieServiceReference;

namespace WCFConsoleApp
{
    class MovieManagement
    {
        public void getAll()
        {
            MovieServiceClient client = new MovieServiceClient();
            Movie[] movies = client.getAll();
            foreach(Movie movie in movies)
            {
                Console.WriteLine("Title = " + movie.Title);
                Console.WriteLine("MovieId = " + movie.MovieId);
                Console.WriteLine("ReleaseDate = " + movie.ReleaseDate);
                Console.WriteLine("RunningTime = " + movie.RunningTime);
                Console.WriteLine("GenreId = " + movie.GenreId);
            }
            client.Close();
        }
    }
}
