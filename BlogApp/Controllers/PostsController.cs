using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete.EfCore;
using Blogapp.Entity;
using Blogapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogapp.Controllers
{
    public class PostsController : Controller{

        private readonly IPostRepository _postRepository;
        public PostsController(IPostRepository postRepository){
            _postRepository = postRepository;
        }
        public IActionResult Index(){
            return View(
                new PostViewModel{
                    Posts = _postRepository.Posts.ToList()
                });
        }

        public async Task<IActionResult> Details(string url){
            return View(await _postRepository.Posts.FirstOrDefaultAsync(p=>p.Url == url));
        }
    }
}