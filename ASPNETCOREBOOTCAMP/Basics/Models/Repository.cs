namespace Basics.Models
{
   public class Repository{

    private static readonly List<Bootcamp> _bootcamp = new();

    static Repository(){
        _bootcamp = new List<Bootcamp>(){
                new Bootcamp() {Id = 1, Title = "Asp Net Core Bootcamp",Description = "23 Ocakta başlıyor.",Image="1.jpg",Tags = new string[]{"aspnet","web geliştirme"},isActive=true,isHome=true},
                new Bootcamp() {Id = 2, Title = "SQL Bootcamp",Description = "27 Ocakta başlıyor.",Image="2.jpg",Tags = new string[]{"data","veri"},isActive=false,isHome=true},
                new Bootcamp() {Id = 3, Title = "Unity Game Bootcamp",Description = "29 Ocakta başlıyor.",Image="3.jpg",Tags = new string[]{"unity","oyun geliştirme"},isActive=true,isHome=false},
        };
    }
    public static List<Bootcamp> Bootcamps{
        get{
            return _bootcamp;
        }
    }

    public static Bootcamp? GetById(int? id){
        return _bootcamp.FirstOrDefault(b => b.Id == id);
    }

   } 
}