using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete.EfCore;
using Blogapp.Entity;

namespace Blogapp.Data.Concrete
{
    public class EfTagRepository : ITagRepository
    {
        private BlogContext _context;
        public EfTagRepository(BlogContext context){
            _context = context;
        }
        public IQueryable<Tag> Tags => _context.Tags;
        public void CreateTag(Tag post)
        {
            _context.Tags.Add(post);
            _context.SaveChanges();
        }
    }
}