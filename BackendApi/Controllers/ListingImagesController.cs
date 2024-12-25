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
    public class ListingImagesController : ControllerBase
    {
        private readonly CarAdsContext _context;

        public ListingImagesController(CarAdsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingImage>>> GetListingImages()
        {
            return await _context.ListingImages.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListingImage>> GetListingImage(int id)
        {
            var listingImage = await _context.ListingImages.FindAsync(id);

            if (listingImage == null)
            {
                return NotFound();
            }

            return listingImage;
        }

        [HttpPost]
        public async Task<ActionResult<ListingImage>> PostListingImage(ListingImage listingImage)
        {
            _context.ListingImages.Add(listingImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetListingImage), new { id = listingImage.ImageId }, listingImage);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListingImage(int id, ListingImage listingImage)
        {
            if (id != listingImage.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(listingImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingImageExists(id))
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
        public async Task<IActionResult> DeleteListingImage(int id)
        {
            var listingImage = await _context.ListingImages.FindAsync(id);
            if (listingImage == null)
            {
                return NotFound();
            }

            _context.ListingImages.Remove(listingImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListingImageExists(int id)
        {
            return _context.ListingImages.Any(e => e.ImageId == id);
        }
    }
}
