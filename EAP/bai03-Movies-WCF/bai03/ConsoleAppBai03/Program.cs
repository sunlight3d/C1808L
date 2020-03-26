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
            MovieManagement movieManagement = new MovieManagement();
           
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
                        movieManagement.ShowAllMovies();
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
