using Microsoft.EntityFrameworkCore;
using Topline.Core.Contracts;
using Topline.Core.DTO;
using Topline.Infrastructure.Data;
using Topline.Infrastructure.Data.Enums;
using Topline.Infrastructure.Data.Models;

namespace Topline.Core.Services
{
    public class TagService : ITagService
    {
        private AppDbContext context;

        public TagService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Tag>> GetAll()
        {
            return await context.Tags.ToListAsync();
        }

        public async Task<Tag> GetById(string id)
        {
            Tag? result = await context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (result == null) throw new NullReferenceException("Item not found!");

            return result;
        }

        public async Task<Tag> CreateTag(TagCreateFormDTO form)
        {
            Tag tag = new()
            {
                Name = form.Name
            };

            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();

            return tag;
        }

        public async Task<Tag> EditTag(string id, TagCreateFormDTO form)
        {
            Tag? tag = await context.Tags.FirstOrDefaultAsync(i => i.Id == id);
            if (tag == null) throw new NullReferenceException("Item not found!");

            tag.Name = form.Name;

            await context.SaveChangesAsync();

            return tag;
        }
    }
}
