using Microsoft.EntityFrameworkCore;

namespace CbeltRetake.Models
{
    public class IdeaContext : DbContext
    {
        public IdeaContext(DbContextOptions<IdeaContext> options) :base(options){}
        public DbSet<User> Users {get;set;}
        public DbSet<Idea> Ideas{get;set;}
        public DbSet<Like> Likes{get;set;}
    }
}