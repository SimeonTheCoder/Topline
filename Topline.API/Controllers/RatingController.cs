using Microsoft.AspNetCore.Mvc;
using Topline.Core.Contracts;
using Topline.Core.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.API.Controllers
{
    [Route("api/ratings")]
    public class RatingController : ControllerBase
    {
        private IRatingService ratingService;

        public RatingController(IRatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] string itemId, [FromQuery] string userId)
        {
            List<Rating> ratings = await ratingService.GetAll();
            if (!string.IsNullOrWhiteSpace(itemId)) ratings = ratings.Where(r => r.ItemId == itemId).ToList();
            if (!string.IsNullOrWhiteSpace(userId)) ratings = ratings.Where(r => r.UserId == userId).ToList();

            if (ratings.Count == 0) return NoContent();

            List<RatingResponseDTO> dtoList = new();

            foreach (Rating rating in ratings)
                dtoList.Add(ratingService.Dto(rating));

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                Rating rating = await ratingService.GetById(id);
                return Ok(ratingService.Dto(rating));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost("rate")]
        public async Task<IActionResult> Rate([FromBody] RatingCreateFormDTO form)
        {
            if (!ModelState.IsValid)
                return BadRequest(string.Join(
                    "; ",
                    ModelState.Values.Select(e => e.Errors).Select(e => string.Join("; ", e.Select(e => e.ErrorMessage)))
                ));

            if (form.Score < 0 || form.Score > 10) return BadRequest("Invalid score!");

            Rating result = await ratingService.Rate(form);
            return Ok(ratingService.Dto(result));
        }

        [HttpPut("change/{id}")]
        public async Task<IActionResult> Change(string id, [FromBody] RatingCreateFormDTO form)
        {
            if (!ModelState.IsValid)
                return BadRequest(string.Join(
                    "; ",
                    ModelState.Values.Select(e => e.Errors).Select(e => string.Join("; ", e.Select(e => e.ErrorMessage)))
                ));

            if (form.Score < 0 || form.Score > 10) return BadRequest("Invalid score!");

            Rating result = await ratingService.ChangeRating(id, form);
            return Ok(ratingService.Dto(result));
        }
    }
}
