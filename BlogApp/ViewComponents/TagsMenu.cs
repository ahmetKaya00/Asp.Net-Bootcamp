using Blogapp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blogapp.ViewComponents

{
    public class TagsMenu : ViewComponent
    {
        private ITagRepository _tagRepository;
        public TagsMenu(ITagRepository tagRepository){
            _tagRepository = tagRepository;
        }

        public async Task<IViewComponentResult> Invoke(){
            return View(await _tagRepository.Tags.ToListAsync());
        }
    }
}