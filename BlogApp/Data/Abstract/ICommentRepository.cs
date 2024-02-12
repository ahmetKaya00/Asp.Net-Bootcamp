using Blogapp.Entity;

namespace Blogapp.Data.Abstract
{
    public interface ICommentRepository{
        IQueryable<Coment> Comments {get;}

        void CreateComments(Coment comment);
    }
}