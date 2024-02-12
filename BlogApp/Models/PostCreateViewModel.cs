
using System.ComponentModel.DataAnnotations;
using Blogapp.Entity;

namespace Blogapp.Models
{
    public class PostCreateViewModel{

        [Required]
        [Display(Name = "Başlık")]
        public string? Title{get;set;}

        [Required]
        [Display(Name = "Açıklama")]
        public string? Description{get;set;}

        [Required]
        [Display(Name = "İçerik")]
        public string? Content{get;set;}

        [Required]
        [Display(Name = "Url")]
        public string? Url{get;set;}
    }
}