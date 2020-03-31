using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFConsoleApp.MovieServiceClient;

namespace WCFConsoleApp
{    
    class MovieManagement
    {
        
        MovieServiceClient.MovieServiceClient client = new MovieServiceClient.MovieServiceClient();
        public void GetAll()
        {            
            List<Movie> movies = client.getAll();
            
            foreach(Movie movie in movies)
            {
                this.printMovie(movie);
            }
            client.Close();
        }
        private void printMovie(Movie movie)
        {
            Console.WriteLine("Title = " + movie.Title);
            Console.WriteLine("MovieId = " + movie.MovieId);
            Console.WriteLine("ReleaseDate = " + movie.ReleaseDate);
            Console.WriteLine("RunningTime = " + movie.RunningTime);
            Console.WriteLine("RunningTime = " + movie.RunningTime);
            Console.WriteLine("GenreId = " + movie.GenreId);
            Console.WriteLine("BoxOffice = " + movie.BoxOffice);
        }
        public void Search()
        {
            Console.WriteLine("Enter text to search : ");
            String text = Console.ReadLine();
            List<Movie> movies = client.Search(text);
            Console.WriteLine("Result here : ");
            foreach (Movie movie in movies)
            {
                this.printMovie(movie);
            }
            client.Close();
        }
        public void Create()
        {

            Console.WriteLine("Enter title : ");
            String title = Console.ReadLine();

            Console.WriteLine("Enter runningTime : ");
            int runningTime = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter GenreId : ");
            int genreId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter box office(int)");
            int boxOffice = Convert.ToInt16(Console.ReadLine());

            Movie newMovie = new Movie()
            {
                BoxOffice = boxOffice,
                Title = title,
                RunningTime = runningTime,
                GenreId = genreId,
            };
            Console.WriteLine("haha");
            client.Add(newMovie);
        }
        public void Delete()
        {
            Console.WriteLine("Enter id to delete : ");
            int id = Convert.ToInt32(Console.ReadLine());
            client.Delete(id);
        }
        public void Edit()
        {
            Console.WriteLine("Enter id to edit : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter title : ");
            String title = Console.ReadLine();

            Console.WriteLine("Enter runningTime : ");
            int runningTime = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter GenreId : ");
            int genreId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter box office(int)");
            int boxOffice = Convert.ToInt16(Console.ReadLine());

            Movie updatedMovie = new Movie()
            {                
                BoxOffice = boxOffice,
                Title = title,
                RunningTime = runningTime,
                GenreId = genreId,
            };
            updatedMovie.MovieId = id;
            client.Edit(updatedMovie);
        }
    }
}
