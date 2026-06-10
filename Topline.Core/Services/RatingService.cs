using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Topline.Core.Contracts;
using Topline.Core.DTO;
using Topline.Infrastructure.Data;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Services
{
    public class RatingService : IRatingService
    {
        private AppDbContext context;
        private UserManager<User> userManager;

        public RatingService(AppDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<List<Rating>> GetAll()
        {
            return await context.Ratings.ToListAsync();
        }

        public async Task<Rating> GetById(string id)
        {
            Rating? result = await context.Ratings.FirstOrDefaultAsync(r => r.Id == id);
            if (result == null) throw new NullReferenceException("Rating not found!");

            return result;
        }

        public async Task<List<Rating>> GetByUserId(string id)
        {
            User? user = await userManager.FindByIdAsync(id);
            if (user == null) throw new NullReferenceException("User not found!");

            List<Rating>? result = await context.Ratings.Where(r => r.UserId == id).ToListAsync();
            return result;
        }

        public async Task<List<Rating>> GetByItemId(string id)
        {
            Item? item = await context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null) throw new NullReferenceException("Item not found!");

            List<Rating>? result = await context.Ratings.Where(r => r.ItemId == id).ToListAsync();
            return result;
        }

        public async Task<Rating> Rate(RatingCreateFormDTO form)
        {
            User? user = await userManager.FindByIdAsync(form.UserId);
            if (user == null) throw new NullReferenceException("User not found!");

            Item? item = await context.Items.FirstOrDefaultAsync(i => i.Id == form.UserId);
            if (item == null) throw new NullReferenceException("Item not found!");

            Rating rating = new()
            {
                ItemId = form.ItemId,
                UserId = form.UserId,
                Date = form.Date,
                Score = form.Score
            };

            await context.Ratings.AddAsync(rating);
            await context.SaveChangesAsync();

            return rating;
        }

        public async Task<Rating> ChangeRating(string id, RatingCreateFormDTO form)
        {
            User? user = await userManager.FindByIdAsync(form.UserId);
            if (user == null) throw new NullReferenceException("User not found!");

            Item? item = await context.Items.FirstOrDefaultAsync(i => i.Id == form.UserId);
            if (item == null) throw new NullReferenceException("Item not found!");

            Rating? rating = await context.Ratings.FirstOrDefaultAsync(r => r.Id == id);
            if (rating == null) throw new NullReferenceException("Rating not found!");

            rating.ItemId = form.ItemId;
            rating.UserId = form.UserId;
            rating.Date = form.Date;
            rating.Score = form.Score;

            await context.SaveChangesAsync();

            return rating;
        }

        public RatingResponseDTO Dto(Rating rating)
        {
            return new RatingResponseDTO()
            {
                Id = rating.Id,
                UserId = rating.UserId,
                ItemId = rating.ItemId,
                Score = rating.Score,
                Date = rating.Date,
            };
        }
    }
}
