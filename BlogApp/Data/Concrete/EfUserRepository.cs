using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete.EfCore;
using Blogapp.Entity;

namespace Blogapp.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private BlogContext _context;
        public EfUserRepository(BlogContext context){
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}