using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete;
using Blogapp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();

var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/{Url}",
    defaults: new {controller = "Posts", action = "Details"}
);

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Posts}/{action=Index}/{id?}"
);

app.Run();
