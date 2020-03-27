using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class MovieModel
    {
        public String Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public int GenreId { get; set; }
        public decimal BoxOffice { get; set; }

    }
}