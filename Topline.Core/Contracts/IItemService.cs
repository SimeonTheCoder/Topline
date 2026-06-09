using Topline.Core.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Contracts
{
    public interface IItemService
    {
        public Task<List<Item>> GetAll();

        public Task<Item> GetById(string id);

        public Task<Item> CreateItem(ItemCreateFormDTO dto);

        public Task<Item> EditItem(string id, ItemCreateFormDTO dto);
    }
}
