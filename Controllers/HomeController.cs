using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using WorldCups.Data;
using WorldCups.Models;

namespace WorldCups.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categoris = new List<Categories>
            {
                new Categories
                {
                    Id = 1,
                    Name = "الملاعب",
                    Icon=" <i class=\"fa fa-futbol-o text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
                    Url="Studiums"

                },

                new Categories
                {
                    Id = 2,
                    Name = "جدول المباريات",
                    Icon=" <i class=\"fa fa-clock-o text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
                    

                },

                new Categories
                {
                    Id = 3,
                    Name = "الفنادق",
                    Icon=" <i class=\"fa fa-bed text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
                    Url="Hotel"
                },

            };
            return View(categoris);
        }


        public IActionResult Studiums()
        {
            var stadiums = new List<Stadiums>
            {
                new Stadiums
                {
                    Id = 1,
                    Name="ملعب الملك فهد الدولي ",
                    Capacity = 68752,
                    City="الرياض",
                    Type="كرة قدم",
                    ConstractionDate=new DateTime(1987,6,18),
                    Owner="الهيئة العامة للرياضة",
                    Length=105,
                    Width=68,
                    Facility=new List<string> {"مواقف سيارات","شاشة عملاقة","مطاعم"},
                    Images="images/Stadiums.jpg"
                },

                 new Stadiums
                {
                    Id = 2,
                    Name="ملعب مدينة الملك عبدالله الرياضية",
                    Capacity = 65000,
                    City="جدة",
                    Type="كرة قدم",
                    ConstractionDate=new DateTime(1987,6,18),
                    Owner="الهيئة العامة للرياضة",
                    Length=105,
                    Width=68,
                    Facility=new List<string> {"مواقف سيارات","شاشة عملاقة","مطاعم"},
                    Images="images/squer.jpg"
                }

            };
            return View(stadiums);
        }
        public IActionResult Hotel()
        {
           var hotel = _context.hotel.ToList(); 
            return View(hotel);
        }

        [HttpPost]
        public IActionResult AddHoteltocart(int id)
        {

            int  count =Convert.ToInt32( HttpContext.Session.GetInt32("count"));
           

   
            count++;

            HttpContext.Session.SetInt32("count", count);    

            return Json(new { count = count });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
