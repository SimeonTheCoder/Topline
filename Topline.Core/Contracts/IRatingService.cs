using Topline.Core.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Contracts
{
    public interface IRatingService
    {
        public Task<List<Rating>> GetAll();

        public Task<Rating> GetById(string id);

        public Task<List<Rating>> GetByUserId(string id);

        public Task<List<Rating>> GetByItemId(string id);

        public Task<Rating> Rate(RatingCreateFormDTO dto);

        public Task<Rating> ChangeRating(string id, RatingCreateFormDTO dto);

        public RatingResponseDTO Dto(Rating rating);
    }
}
