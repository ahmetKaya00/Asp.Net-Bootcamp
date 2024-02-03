using Blogapp.Entity;

namespace Blogapp.Data.Abstract
{
    public interface IPostRepository{
        IQueryable<Post> Posts {get;}

        void CreatePost(Post post);
    }
}