using FileUploadControl;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTickets.Data;
using OnlineMovieTickets.Models;
using OnlineMovieTickets.Models.ViewModels;

namespace OnlineMovieTickets.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UuploadInterface _upload;

        public AdminController(ApplicationDbContext context, UuploadInterface upload)
        {
            _upload = upload;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(List<IFormFile>files, MovieDetailViewmodel vmodel, MovieDetails movie)
        {
            string path = string.Empty;
            movie.Movie_Name = vmodel.Name;
            movie.Movie_Description = vmodel.Description;
            movie.DateAndTime = vmodel.DateofMovie;
            foreach(var item in files)
            {
                path = Path.GetFileName(item.FileName.Trim());
                movie.MoviePicture = "~/uploads/" + path;
            }
            _upload.uploadfilemultiple(files);
            _context.MovieDetails.Add(movie);
            _context.SaveChanges();
            TempData["Sucess"] = "Save Your Movie";
            return RedirectToAction("Create","Admin");
            
        }
        [HttpGet]
        public IActionResult CheckBookSeat()
        {
            var getBookingTable = _context.BookingTable.ToList().OrderByDescending(a => a.Datetopresent);
            return View(getBookingTable);
        }
        [HttpGet]
        public IActionResult GetUserDetails() {
            var getUserTable = _context.UserClaims.ToList();
            return View(getUserTable);
        }
    }
}

