using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFConsoleApp.MovieServiceReference;

namespace WCFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int choice = -1;
            MovieManagement movieManagement = new MovieManagement();
            while (choice != 5) {
                Console.WriteLine("1.Show all movies");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Enter your choice(1-5): ");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        movieManagement.getAll();
                        break;
                    case 2:
                        
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("End program");
        }
    }
}
