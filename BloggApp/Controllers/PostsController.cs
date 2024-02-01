using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace Blogapp.Controllers
{
    public class PostsController : Controller{

        private readonly IPostRepository _repository;
        public PostsController(IPostRepository context){
            _repository = context;
        }
        public IActionResult Index(){
            return View(_repository.Posts.ToList());
        }
    }
}