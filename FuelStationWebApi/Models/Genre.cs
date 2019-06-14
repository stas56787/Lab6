using System.Collections.Generic;

namespace FuelStationWebApi.Models
{
    public class Genre
    {
        //Id Топлива
        public int GenreID { get; set; }
        public string NameGenre { get; set; }
        public virtual ICollection<TVShow> TVShows { get; set; }
        public Genre()
        {
            TVShows = new List<TVShow>();

        }
    }
}
