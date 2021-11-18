using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLiteWebApi.Entities;

namespace SQLiteWebApi.Controllers
{

    private readonly DatabaseContext databaseContext;



    [Route("api/[controller]")]
    [ApiController]
    public class MtbTourControllerEmpty : ControllerBase
    {
        [HttpGet]
        public List<MountainbikeTour> GetTours()
        {

        }
    }
}
