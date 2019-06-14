using FuelStationWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelStationWebApi.Data
{
    public class TVShowsContext : DbContext
    {
        public TVShowsContext(DbContextOptions<TVShowsContext> options) : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<TVShow> TVShows { get; set; }
    }
}
