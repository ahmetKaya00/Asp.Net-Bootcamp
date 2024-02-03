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
                        new Tag {Text = "Web Geliştirme", Url="web-progralama"},
                        new Tag {Text = "Backend", Url="backend"},
                        new Tag {Text = "Froundend", Url="froundend"},
                        new Tag {Text = "Full Stack", Url="full-stack"},
                        new Tag {Text = "Game", Url="game"}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User{UserName = "ahmetkaya"},
                        new User{UserName = "aysetilmaz"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.Net Core",
                            Url="aspnet-core",
                            Content = "Asp.net core dersleri",
                            Image = "1.jpg",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-7),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Post{
                            Title = "Unity Game",
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
                            Url="beckend",
                            Content = "Backend dersleri",
                            Image = "2.jpg",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-12),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}