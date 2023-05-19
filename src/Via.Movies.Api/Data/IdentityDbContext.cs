using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Models;

namespace Via.Movies.Api.Data
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext(
            DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }
    }
}