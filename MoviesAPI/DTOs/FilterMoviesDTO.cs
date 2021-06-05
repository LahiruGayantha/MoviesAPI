using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class FilterMoviesDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }

        public string Title { get; set; }
        public int GenreId { get; set; }
        public bool InTheator { get; set; }
        public bool UpCommingReleases { get; set; }
        public string  OrderBy { get; set; }
        public bool Ascending { get; set; } = true;
    }
}
