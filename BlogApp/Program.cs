using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete;
using Blogapp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository,EfCommentsRepository>();
builder.Services.AddScoped<IUserRepository,EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = "/Users/Login";
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{Url}",
    defaults: new {controller = "Posts", action = "Details"}
);

app.MapControllerRoute(
    name: "post_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new {controller = "Posts", action = "Index"}
);

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Posts}/{action=Index}/{id?}"
);

app.Run();
