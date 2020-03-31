using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int choice = -1;
            MovieManagement movieManagement = new MovieManagement();
            while (choice != 6) {
                Console.WriteLine("1.Show all movies");
                Console.WriteLine("2.Search movies");
                Console.WriteLine("3.Insert 1 movie");
                Console.WriteLine("4.Delete 1 movie");
                Console.WriteLine("5.Edit 1 movie");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter your choice(1-5): ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        movieManagement.GetAll();
                        break;
                    case 2:
                        movieManagement.Search();
                        break;
                    case 3:
                        movieManagement.Create();
                        break;
                    case 4:
                        movieManagement.Delete();
                        break;
                    case 5:
                        movieManagement.Edit();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("End program");
        }
    }
}
