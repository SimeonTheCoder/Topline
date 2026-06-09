using Microsoft.EntityFrameworkCore;
using Topline.Core.Contracts;
using Topline.Core.DTO;
using Topline.Infrastructure.Data;
using Topline.Infrastructure.Data.Enums;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Services
{
    public class ItemService : IItemService
    {
        private AppDbContext context;

        public ItemService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Item>> GetAll()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<Item> GetById(string id)
        {
            Item? result = await context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (result == null) throw new NullReferenceException("Item not found!");

            return result;
        }

        public async Task<Item> CreateItem(ItemCreateFormDTO form)
        {
            ItemType type;
            Enum.TryParse(form.Type, out type);

            Item item = new()
            {
                Name = form.Name,
                Artist = form.Artist,
                Description = form.Description,
                Type = type,
                Year = form.Year,
            };

            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task<Item> EditItem(string id, ItemCreateFormDTO form)
        {
            Item? item = await context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null) throw new NullReferenceException("Item not found!");

            ItemType type;
            Enum.TryParse(form.Type, out type);

            item.Name = form.Name;
            item.Artist = form.Artist;
            item.Description = form.Description;
            item.Type = type;
            item.Year = form.Year;

            await context.SaveChangesAsync();

            return item;
        }
    }
}
