using Blogapp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggApp.ViewComponents
{
    public class NewPost : ViewComponent{
         private IPostRepository _postRepository;
        public NewPost(IPostRepository tagRepository){
            _postRepository = tagRepository;
        }

        public async Task<IViewComponentResult> Invoke(){
            return View(await _postRepository.Posts
            .OrderByDescending(p=>p.PublishedOn)
            .Take(5)
            .ToListAsync());
        }
    }
}