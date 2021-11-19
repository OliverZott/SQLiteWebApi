using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteWebApi.Entities;

namespace SQLiteWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MtbTourController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<MountainbikeTour> _dbSet;



        public MtbTourController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<MountainbikeTour>();  // Set-Entity for querying
        }

        [HttpGet]
        public async Task<ActionResult> GetTours()  // ir return result: List<MountainbikeTour>
        {
            IQueryable<MountainbikeTour> query = _dbSet;
            var tours = await query.AsNoTracking().ToListAsync();
            return Ok(tours);

        }

        [HttpGet("{id:int}", Name = "GetTour")]
        public async Task<ActionResult> GetTour(int id)
        {
            IQueryable<MountainbikeTour> query = _dbSet;
            var tour = await query.FirstOrDefaultAsync(q => q.TourId == id);
            return Ok(tour);

        }
    }
}
