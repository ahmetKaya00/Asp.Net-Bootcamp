using Blogapp.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blogapp.Data.Concrete.EfCore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options){
            
        }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Coment> Coments => Set<Coment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
    }
}