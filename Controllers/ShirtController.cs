using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIdemo.Data;
using WebAPIdemo.Model;

namespace WebAPIdemo.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class ShirtController : ControllerBase
        {
            private readonly AppDbContext _context;

            public ShirtController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/shirt
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Shirt>>> GetAll()
            {
                return await _context.Shirts.ToListAsync();
            }

            // GET: api/shirt/1
            [HttpGet("{id}")]
            public async Task<ActionResult<Shirt>> GetById(int id)
            { 
                var shirt = await _context.Shirts.FindAsync(id);
                if (shirt == null) return NotFound();
                return shirt;
            }

            // POST: api/shirt
            [HttpPost]
            public async Task<ActionResult<Shirt>> Create(Shirt shirt)
            {
                _context.Shirts.Add(shirt);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = shirt.Id }, shirt);
            }

            // PUT: api/shirt/1
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Shirt updatedShirt)
            {
                if (id != updatedShirt.Id) return BadRequest();

                _context.Entry(updatedShirt).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            // DELETE: api/shirt/1
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var shirt = await _context.Shirts.FindAsync(id);
                if (shirt == null) return NotFound();

                _context.Shirts.Remove(shirt);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }



