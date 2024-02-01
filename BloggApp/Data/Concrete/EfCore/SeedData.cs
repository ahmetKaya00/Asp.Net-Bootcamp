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
                        new Tag {Text = "Web Geliştirme"},
                        new Tag {Text = "Backend"},
                        new Tag {Text = "Froundend"},
                        new Tag {Text = "Full Stack"},
                        new Tag {Text = "Game"}
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
                            Content = "Asp.net core dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-7),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Post{
                            Title = "Unity Game",
                            Content = "Unity Game dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 2
                        },
                        new Post{
                            Title = "Backend",
                            Content = "Backend dersleri",
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