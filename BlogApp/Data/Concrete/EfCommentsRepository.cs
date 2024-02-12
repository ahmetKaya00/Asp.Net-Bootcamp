using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete.EfCore;
using Blogapp.Entity;

namespace Blogapp.Data.Concrete
{
    public class EfCommentsRepository : ICommentRepository
    {
        private BlogContext _context;
        public EfCommentsRepository(BlogContext context){
                _context = context;
        }
        public IQueryable<Coment> Comments => _context.Coments;

        public void CreateComments(Coment comments)
        {
            _context.Coments.Add(comments);
            _context.SaveChanges();
        }

    }
}