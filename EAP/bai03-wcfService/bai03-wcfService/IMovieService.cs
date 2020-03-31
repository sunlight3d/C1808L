using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bai03_wcfService
{
    //File cs: chua interface, chi chua cac method, ko chua phan thuc thi
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovieService" in both code and config file together.
    [ServiceContract]
    public interface IMovieService
    {
        [OperationContract]
        List<Movie> getAll();
        
        [OperationContract]
        List<Movie> Search(String text);

        [OperationContract]
        void Add(Movie m);

        [OperationContract]
        void Edit(Movie m);

        [OperationContract]
        void Delete(int id);

    }
}
