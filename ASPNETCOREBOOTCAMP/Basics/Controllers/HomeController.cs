using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Basics.Models;

namespace Basics.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Repository.Bootcamps);
    }

    public IActionResult Contact()
    {
        return View();
    }
}
