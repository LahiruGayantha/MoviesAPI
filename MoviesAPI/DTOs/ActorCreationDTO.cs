using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class ActorCreationDTO
    {
        public int PersonId { get; set; }
        public string Charactor { get; set; }
        public int Order { get; set; }
    }
}
