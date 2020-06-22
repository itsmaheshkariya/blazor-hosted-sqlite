using Microsoft.EntityFrameworkCore;
using Fullstack.Shared;
namespace Fullstack.Server.Models {
    public class UserContext : DbContext {
        public UserContext (DbContextOptions<UserContext> options) : base (options) { }
        public DbSet<User> Users { get; set; }
    }
}
