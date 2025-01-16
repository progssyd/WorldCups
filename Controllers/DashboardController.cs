using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WorldCups.Data;
using WorldCups.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WorldCups.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public DashboardController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult EditCategories(int id)
        {
            var search = _context.categories.SingleOrDefault(c => c.Id == id);
            if (search != null)
            {
                return View("editcategories", search);
            }

            return NotFound();
           
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpdateCategories(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _context.categories.Update(categories); 
                _context.SaveChanges();
                return RedirectToAction("Categories");
            }

            return View("EditCategories");

           
        }


       

        public IActionResult UpdateCategories1(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _context.categories.Update(categories);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            }

            return View("EditCategories");


        }


        public IActionResult CreateNewCatgeroies(Categories categories) // insert 
        {
            _context.categories.Add(categories); // create new record
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }

        public IActionResult CreateNewCategorisTransportation(CategorisTransportation categorisTransportation)
        {
            _context.Add(categorisTransportation);
            _context.SaveChanges();
            return RedirectToAction("CategorisTransportation");
        }
        public IActionResult Categories(string Name) 
        {
            if(Name !=null)
            {
               var sewrach = _context.categories.Where(s=>s.Name.Contains(Name)).ToList();
                      return View(sewrach);
            }
            var getdata=_context.categories.ToList();
            return View(getdata);
        }

        public IActionResult CategorisTransportation()
        {
            var getdata=_context.transportations.ToList();   
            return View(getdata);
        }



        public IActionResult Hotels() {
          
            var getdata=_context.hotel.ToList();
            return View(getdata);
        
        }

        public async Task<IActionResult> CreateNewHotel(Hotel hotel, IFormFile photo)

        {


            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            hotel.Images = photo.FileName;


            _context.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Hotels");
        
        }


        public  IActionResult CreateNewTransport(Transport transpor, IFormFile photo )

        {


            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            transpor.Images = photo.FileName;
          //  transpor.vehicle.Id = vh;

            _context.Add(transpor);
            _context.SaveChanges();
            return RedirectToAction("Transport");

        }

        public IActionResult Transport()
        {

            var getdata = _context.transportations.ToList();
            ViewBag.getdata = getdata;
            
            var model = _context.transports.ToList();
            var transport = _context.transports.Join(

                _context.transportations,

                Transport => Transport.CategorisTransportationId,
                transportations => transportations.Id,

                (Transport, transportations) => new
                {
                    Id =Transport.Id,
                    Name =Transport.Name,
                    Capacity = Transport.Capacity,
                    Color = Transport.Color,
                    Categoriesid = transportations.Id,
                    CategoriesName = transportations.Name,
                    Images = Transport.Images,

                }



                ).ToList();
            ViewBag.Transport = transport;
            return View(model);
        }
        [HttpPost]
        public IActionResult AdvanceSearch(string Name)
        {
            if (Name != null)
            {
                var sewrach = _context.categories.Where(s => s.Name.Contains(Name)).ToList();
                return PartialView("_Partiial/_CateogriesPartial", sewrach);
            }

            var Categories = _context.categories.ToList(); 
            return PartialView("_Partiial/_CateogriesPartial", Categories);
        }
        public IActionResult DeleteCategories(int id)
        {
            var del = _context.categories.SingleOrDefault(c => c.Id == id);
            if (del != null)
            {
                _context.categories.Remove(del);
                _context.SaveChanges();
            }

            var Categories = _context.categories.ToList();
            return PartialView("_Partiial/_CateogriesPartial", Categories);

        }

    }
}
