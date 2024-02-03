using Blogapp.Entity;

namespace Blogapp.Data.Abstract
{
    public interface ITagRepository{
        IQueryable<Tag> Tags {get;}

        void CreateTag(Tag post);
    }
}