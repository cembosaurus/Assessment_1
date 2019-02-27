using DataStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace DataStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockersController : Controller
    {
        private readonly ILockersRepository _repo;

        public LockersController(ILockersRepository repo)
        {
            _repo = repo;
        }



        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _repo.Lockers();

            return Ok(result);

        }

    }
}
