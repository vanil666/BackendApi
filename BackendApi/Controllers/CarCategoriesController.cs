using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApi.Models;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCategoriesController : ControllerBase
    {
        private readonly CarAdsContext _context;

        public CarCategoriesController(CarAdsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarCategory>>> GetCarCategories()
        {
            return await _context.CarCategories.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<CarCategory>> GetCarCategory(int id)
        {
            var carCategory = await _context.CarCategories.FindAsync(id);

            if (carCategory == null)
            {
                return NotFound();
            }

            return carCategory;
        }

  
        [HttpPost]
        public async Task<ActionResult<CarCategory>> PostCarCategory(CarCategory carCategory)
        {
            _context.CarCategories.Add(carCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarCategory), new { id = carCategory.CategoryId }, carCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarCategory(int id, CarCategory carCategory)
        {
            if (id != carCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(carCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarCategory(int id)
        {
            var carCategory = await _context.CarCategories.FindAsync(id);
            if (carCategory == null)
            {
                return NotFound();
            }

            _context.CarCategories.Remove(carCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarCategoryExists(int id)
        {
            return _context.CarCategories.Any(e => e.CategoryId == id);
        }
    }
}
