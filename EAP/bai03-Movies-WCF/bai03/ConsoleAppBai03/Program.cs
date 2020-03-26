using ConsoleAppBai03.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBai03


{
    class Program
    {
        static void Main(string[] args)
        {
            
            int choice = -1;
            while (choice != 7) {
                Console.WriteLine("1. List all movies");
                Console.WriteLine("2. Search movies by title");
                Console.WriteLine("3. Get detail movie by Id");
                Console.WriteLine("4. Edit movie' information");
                Console.WriteLine("5. Add movie");
                Console.WriteLine("6. Delete movie");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice:");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice) {
                    case 1:
                        MoviesServiceClient moviesServiceClient = new MoviesServiceClient();
                        ServiceReference1.Movie[] movies = moviesServiceClient.GetAll();
                        foreach(Movie movie in movies) {
                            Console.WriteLine(movie);
                        }
                        moviesServiceClient.Close();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;

                }
            }
            Console.WriteLine("End program");
            
        }
    }
}
