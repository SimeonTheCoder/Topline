using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Topline.API.Extensions;
using Topline.Core.Contracts;
using Topline.Core.Services;
using Topline.Infrastructure.Data;
using Topline.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddControllers();

var app = builder.Build();

await app.SeedUsersAsync();

app.MapControllers();

app.Run();