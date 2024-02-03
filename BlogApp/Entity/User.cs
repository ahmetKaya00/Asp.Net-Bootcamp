namespace Blogapp.Entity
{
    public class User{
        public int UserId { get; set; }
        public string? UserName {get;set;}
        public List<Post> Posts {get;set;} = new List<Post>();
        public List<Coment> Coments {get;set;} = new List<Coment>();
    }
}