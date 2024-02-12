using Blogapp.Entity;

namespace Blogapp.Data.Abstract
{
    public interface IUserRepository{
        IQueryable<User> Users {get;}

        void CreateUser(User user);
    }
}