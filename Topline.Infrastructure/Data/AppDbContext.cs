using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Topline.Infrastructure.Data.Models;

namespace Topline.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<TaggedItem> TaggedItems { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
