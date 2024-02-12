using System.Security.Claims;
using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete.EfCore;
using Blogapp.Entity;
using Blogapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogapp.Controllers
{
    public class PostsController : Controller{

        private IPostRepository _postRepository;
        private ICommentRepository _commentcrRepository;
        public PostsController(IPostRepository postRepository,ICommentRepository commentcrRepository){
            _postRepository = postRepository;
            _commentcrRepository = commentcrRepository;
        }
        public async Task<IActionResult> Index(string tag){

            var claims = User.Claims;

            var posts = _postRepository.Posts;

            if(!string.IsNullOrEmpty(tag)){
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }

            return View(new PostViewModel{Posts = await posts.ToListAsync()});
        }

        public async Task<IActionResult> Details(string url){
            return View(await _postRepository
                        .Posts
                        .Include(x=> x.Tags)
                        .Include(x=>x.Coments)
                        .ThenInclude(x => x.User)
                        .FirstOrDefaultAsync(p=>p.Url == url));
        }

        [HttpPost]
        public JsonResult AddComment(int PostId, string Text){

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);


            var entity = new Coment{
                PostId = PostId,
                Text = Text,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")
            };
            
            _commentcrRepository.CreateComments(entity);
            
            return Json(new {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });
        }

        [Authorize]
        public IActionResult Create(){
            return View();
        }

        [Authorize]
        [HttpPost]
         public IActionResult Create(PostCreateViewModel model){

            if(ModelState.IsValid){

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _postRepository.CreatePost(
                    new Post{
                        Title = model.Title,
                        Content = model.Content,
                        Url = model.Url,
                        UserId = int.Parse(userId ?? ""),
                        PublishedOn = DateTime.Now,
                        Image = "1.jpg",
                        IsActive = false
                    });
                    return RedirectToAction("Index");
            }
            return View(model);
        }  

        [Authorize]
        public async Task<IActionResult> List(){

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var posts = _postRepository.Posts;

            if(string.IsNullOrEmpty(role)){
                posts = posts.Where(i=>i.UserId==userId);
            }
            return View(await posts.ToListAsync());
        }
    }
}