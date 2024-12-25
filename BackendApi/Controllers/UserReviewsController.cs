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
    public class UserReviewsController : ControllerBase
    {
        private readonly CarAdsContext _context;

        public UserReviewsController(CarAdsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReview>>> GetUserReviews()
        {
            return await _context.UserReviews.ToListAsync();
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReview>> GetUserReview(int id)
        {
            var userReview = await _context.UserReviews.FindAsync(id);

            if (userReview == null)
            {
                return NotFound();
            }

            return userReview;
        }

        [HttpPost]
        public async Task<ActionResult<UserReview>> PostUserReview(UserReview userReview)
        {
            _context.UserReviews.Add(userReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserReview), new { id = userReview.ReviewId }, userReview);
        }

   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserReview(int id, UserReview userReview)
        {
            if (id != userReview.ReviewId)
            {
                return BadRequest();
            }

            _context.Entry(userReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserReviewExists(id))
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
        public async Task<IActionResult> DeleteUserReview(int id)
        {
            var userReview = await _context.UserReviews.FindAsync(id);
            if (userReview == null)
            {
                return NotFound();
            }

            _context.UserReviews.Remove(userReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserReviewExists(int id)
        {
            return _context.UserReviews.Any(e => e.ReviewId == id);
        }
    }
}
