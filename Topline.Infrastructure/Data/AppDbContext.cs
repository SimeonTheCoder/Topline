using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Topline.Infrastructure.Data.Models;

namespace Topline.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        
    }
}
