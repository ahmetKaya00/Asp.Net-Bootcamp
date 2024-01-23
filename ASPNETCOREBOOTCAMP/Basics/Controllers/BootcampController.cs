using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class BootcampController : Controller{

        public IActionResult Index(){
            var kurs = new Bootcamp();

            kurs.Id = 1;
            kurs.Title = "Asp Net Core Bootcamp";
            kurs.Description = "23 Ocakta Başlıyor.";

            return View(kurs);
        }

        public IActionResult List(){
            var kurslar = new List<Bootcamp>()
            {
                new Bootcamp() {Id = 1, Title = "Asp Net Core Bootcamp",Description = "23 Ocakta başlıyor.",Image="1.jpg"},
                new Bootcamp() {Id = 2, Title = "SQL Bootcamp",Description = "27 Ocakta başlıyor.",Image="2.jpg"},
                new Bootcamp() {Id = 3, Title = "Unity Game Bootcamp",Description = "29 Ocakta başlıyor.",Image="3.jpg"},
                new Bootcamp() {Id = 4, Title = "Full Stack Bootcamp",Description = "1 Şubatta başlıyor.",Image="4.jpg"},
            };
            return View(kurslar);
        }
    }
    
}