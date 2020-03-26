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
        
        private Service1Client client;
        public void InsertMovie()
        {

        }
        public void ShowAllMovies()
        {
            try
            {
                client = new Service1Client();
                foreach (Movie movie in client.GetAll())
                {
                    Console.WriteLine(movie);
                }
                client.Close();
            }
            catch (Exception e) {
                Console.WriteLine("Cannot get all movies"+e.ToString());
            }
        }
        public void UpdateMovie()
        {

        }

    }
}
