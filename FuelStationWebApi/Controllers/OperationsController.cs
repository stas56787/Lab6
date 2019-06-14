using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FuelStationWebApi.Models;
using FuelStationWebApi.Data;
using Microsoft.EntityFrameworkCore;
using FuelStationWebApi.ViewModels;

namespace FuelStationWebApi.Controllers
{
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        private readonly TVShowsContext _context;
        public OperationsController(TVShowsContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public List<TVShowViewModel> Get()
        {
            var ovm = _context.TVShows.Include(f => f.Genre).Select(o=> 
                new TVShowViewModel
                {
                    TVShowID = o.TVShowID,
                    GenreID = o.GenreID,
                    NameGenre = o.Genre.NameGenre,
                    NameShow = o.NameShow,
                    DescriptionShow = o.DescriptionShow

                });
            return ovm.OrderByDescending(t=>t.TVShowID).Take(20).ToList();
        }
        // GET api/values
        [HttpGet("fuels")]
        [Produces("application/json")]
        public IEnumerable<Genre> GetFuels()
        {
            return _context.Genres.ToList();
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TVShow operation = _context.TVShows.FirstOrDefault(x => x.TVShowID == id);
            if (operation == null)
                return NotFound();
            return new ObjectResult(operation);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TVShow tvShow)
        {
            if (tvShow == null)
            {
                return BadRequest();
            }

            _context.TVShows.Add(tvShow);
            _context.SaveChanges();
            return Ok(tvShow);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]TVShow tvShow)
        {
            if (tvShow == null)
            {
                return BadRequest();
            }
            if (!_context.TVShows.Any(x => x.TVShowID == tvShow.TVShowID))
            {
                return NotFound();
            }

            _context.Update(tvShow);
            _context.SaveChanges();


            return Ok(tvShow);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TVShow tvShow = _context.TVShows.FirstOrDefault(x => x.TVShowID == id);
            if (tvShow == null)
            {
                return NotFound();
            }
            _context.TVShows.Remove(tvShow);
            _context.SaveChanges();
            return Ok(tvShow);
        }
    }
}
