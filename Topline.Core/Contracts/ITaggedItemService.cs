using Topline.Core.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Contracts
{
    public interface ITaggedItemService
    {
        public Task<List<TaggedItem>> GetAll();

        public Task<TaggedItem> GetById(string id);

        public Task<List<Tag>> GetByItemId(string id);

        public Task<List<Item>> GetByTagId(string id);

        public Task<TaggedItem> AttachTag(string itemId, string tagId);

        public Task<TaggedItem> RemoveTag(string itemId, string tagId);
    }
}
