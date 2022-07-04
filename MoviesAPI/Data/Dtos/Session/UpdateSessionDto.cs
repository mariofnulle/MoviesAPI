using System;

namespace MoviesAPI.Data.Dtos.Session
{
    public class UpdateSessionDto
    {
        public int TheatherId { get; set; }
        public int MovieId { get; set; }
        public DateTime EndingTime { get; set; }
    }
}
