using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entities
{
    public class MovieActors
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public Movie Movie { get; set; }
        public Person Person { get; set; }
        public string Charactor { get; set; }
        public int Order { get; set; }
    }
}
