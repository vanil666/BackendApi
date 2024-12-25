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
    public class ListingCategoriesController : ControllerBase
    {
        private readonly CarAdsContext _context;

        public ListingCategoriesController(CarAdsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingCategory>>> GetListingCategories()
        {
            return await _context.ListingCategories.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ListingCategory>> GetListingCategory(int id)
        {
            var listingCategory = await _context.ListingCategories.FindAsync(id);

            if (listingCategory == null)
            {
                return NotFound();
            }

            return listingCategory;
        }

        [HttpPost]
        public async Task<ActionResult<ListingCategory>> PostListingCategory(ListingCategory listingCategory)
        {
            _context.ListingCategories.Add(listingCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetListingCategory), new { id = listingCategory.ListingCategoryId }, listingCategory);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListingCategory(int id, ListingCategory listingCategory)
        {
            if (id != listingCategory.ListingCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(listingCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingCategoryExists(id))
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
        public async Task<IActionResult> DeleteListingCategory(int id)
        {
            var listingCategory = await _context.ListingCategories.FindAsync(id);
            if (listingCategory == null)
            {
                return NotFound();
            }

            _context.ListingCategories.Remove(listingCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListingCategoryExists(int id)
        {
            return _context.ListingCategories.Any(e => e.ListingCategoryId == id);
        }
    }
}
