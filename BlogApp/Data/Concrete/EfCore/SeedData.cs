using Blogapp.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blogapp.Data.Concrete.EfCore
{
    public static class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                if(!context.Tags.Any()){
                    context.Tags.AddRange(
                        new Tag {Text = "Web Geliştirme", Url="web-progralama", Color = TagColor.warning},
                        new Tag {Text = "Backend", Url="backend", Color = TagColor.secondary},
                        new Tag {Text = "Froundend", Url="froundend", Color = TagColor.primary},
                        new Tag {Text = "Full Stack", Url="full-stack", Color = TagColor.success},
                        new Tag {Text = "Game", Url="game", Color = TagColor.danger}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User{UserName = "ahmetkaya", Name = "Ahmet Kaya",Email="info@ahmetkaya.com",Password = "123456", Image = "ahmet.jpg"},
                        new User{UserName = "mesudekaya", Name = "Mesude Kaya",Email="info@mesudekaya.com",Password = "123456", Image = "11.jpg"}

                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.Net Core",
                            Description = "Asp.Net Core Dersleri",
                            Url="aspnet-core",
                            Content = "Asp.net core dersleri",
                            Image = "1.jpg",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-7),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 1,
                            Coments = new List<Coment>{
                                new Coment{Text = "Güzel bir blog.", PublishedOn =DateTime.Now.AddDays(-10), UserId = 1},
                                new Coment{Text = "Mutlaka okuyun.", PublishedOn = new DateTime(), UserId = 2},
                            }
                        },
                        new Post{
                            Title = "Unity Game",
                            Description = "Unity Game Dersleri",
                            Url="unity-game",
                            Content = "Unity Game dersleri",
                            Image = "3.jpg",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 2
                        },
                        new Post{
                            Title = "Backend",
                            Description = "Backend Dersleri",
                            Url="beckend",
                            Content = "Backend dersleri",
                            Image = "2.jpg",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-12),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}