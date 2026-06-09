using Topline.Core.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Contracts
{
    public interface ITagService
    {
        public Task<List<Tag>> GetAll();

        public Task<Tag> GetById(string id);

        public Task<Tag> CreateTag(TagCreateFormDTO dto);

        public Task<Tag> EditTag(string id, TagCreateFormDTO dto);
    }
}
