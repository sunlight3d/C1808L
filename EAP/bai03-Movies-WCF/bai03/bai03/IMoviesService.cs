using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bai03
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMoviesService" in both code and config file together.
    [ServiceContract]
    public interface IMoviesService
    {
        
         [OperationContract]
        List<Movie> GetAll();
        
        [OperationContract]
        List<Movie> Search(string Title);
        
        [OperationContract]
        Movie GetById(int Id);
        
        [OperationContract]
        void Add(Movie m);
        
        [OperationContract]
        void Edit(Movie m);
        [OperationContract]
        void Delete(int Id);
         
    }
}
