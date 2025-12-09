using IceCube.Context;
using IceCube.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IceCube.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatIdiomasController : ControllerBase
    {
        private readonly IceCube_Apicontext _context;

        public CatIdiomasController(IceCube_Apicontext context)
        {
            _context = context;
        }

        // GET: api/CatIdiomas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatIdioma>>> GetCatIdiomas()
        {
            var list = await _context.CatIdioma.ToListAsync();
            return Ok(list);
        }
    }
}
