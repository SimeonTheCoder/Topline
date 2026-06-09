using Microsoft.EntityFrameworkCore;
using Topline.Core.Contracts;
using Topline.Core.DTO;
using Topline.Infrastructure.Data;
using Topline.Infrastructure.Data.Enums;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Services
{
    public class TaggedItemService : ITaggedItemService
    {
        private AppDbContext context;
        
        private ITagService tagService;

        public TaggedItemService(AppDbContext context, ITagService tagService)
        {
            this.context = context;
            this.tagService = tagService;
        }

        public async Task<List<TaggedItem>> GetAll()
        {
            return await context.TaggedItems.ToListAsync();
        }

        public async Task<TaggedItem> GetById(string id)
        {
            TaggedItem? result = await context.TaggedItems.FirstOrDefaultAsync(ti => ti.Id == id);
            if (result == null) throw new NullReferenceException("Tag not found for song!");

            return result;
        }


        public async Task<List<Tag>> GetByItemId(string id)
        {
            List<TaggedItem> attached = await context.TaggedItems.Where(ti => ti.ItemId == id).ToListAsync();

            List<Tag> tags = new();

            foreach (TaggedItem attachedTag in attached)
                tags.Add(await tagService.GetById(attachedTag.TagId));

            return tags;
        }

        public async Task<List<Item>> GetByTagId(string id)
        {
            List<TaggedItem> attached = await context.TaggedItems.Where(ti => ti.TagId == id).ToListAsync();

            List<Item?> items = new();

            foreach (TaggedItem attachedTag in attached)
                items.Add(await context.Items.FirstOrDefaultAsync(i => i.Id == attachedTag.ItemId));

            return items!;
        }

        public async Task<TaggedItem> AttachTag(string itemId, string tagId)
        {
            Item? item = await context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
            if (item == null) throw new NullReferenceException("Item not found!");

            Tag tag = await tagService.GetById(tagId);

            TaggedItem attached = new()
            {
                ItemId = item.Id,
                TagId = tag.Id
            };

            await context.TaggedItems.AddAsync(attached);
            await context.SaveChangesAsync();

            return attached;
        }

        public async Task<TaggedItem> RemoveTag(string itemId, string tagId)
        {
            TaggedItem? tag = await context.TaggedItems.FirstOrDefaultAsync(ti => ti.TagId == tagId && ti.ItemId == itemId);
            if (tag == null) throw new NullReferenceException("Tag isn't attached to item!");

            context.TaggedItems.Remove(tag);
            await context.SaveChangesAsync();

            return tag;
        }
    }
}
