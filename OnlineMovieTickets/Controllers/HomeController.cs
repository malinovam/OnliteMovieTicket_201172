using AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTickets.Data;
using OnlineMovieTickets.Models;
using OnlineMovieTickets.Models.ViewModels;
using System.Diagnostics;

namespace OnlineMovieTickets.Controllers
{
    public class HomeController : Controller
    {
        int count = 1;
        bool flag = true;
        private UserManager<ApplicationUser> _usermanager;
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
      //  private readonly ILogger<HomeController> _logger;

       // public HomeController(ILogger<HomeController> logger)
        //{
          //  _logger = logger;
        //}

        public IActionResult Index()
        {
            var getMovieList = _context.MovieDetails.ToList();
            return View(getMovieList);
        }
        [HttpGet]
        public IActionResult BookNow(int Id)
        {
            BookNowViewModel viewModel = new BookNowViewModel();
            var item = _context.MovieDetails.Where(a=>a.Id == Id).FirstOrDefault();
            viewModel.Movie_Name = item.Movie_Name;
            //viewModel.Movie_Date = item.DateAndTime;
            viewModel.MovieId = Id;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BookNow(BookNowViewModel viewModel)
        {
            List<BookingTable> booking = new List<BookingTable>();
            List<Cart> carts = new List<Cart>();
            string seatno = viewModel.SeatNo.ToString();
            int movieId = viewModel.MovieId;

            string [] seatnoArray = seatno.Split(',');
            count = seatnoArray.Length;
            if (chechseat(seatno, movieId) == false)
            {
                foreach(var item in seatnoArray)
                {
                    carts.Add(new Cart { Amount = 150, MovieId = viewModel.MovieId, UserId = _usermanager.GetUserId(HttpContext.User), seatno = item });

                }
                foreach(var item in carts)
                {
                    _context.Cart.Add(item);
                    _context.SaveChanges();
                }
                TempData["Succes"] = "Seat no Booked";
                
            }
            else
            {
                TempData["seatnomg"] = "Chaange";
            }
            return RedirectToAction("BookNow");
        }

        private bool chechseat(string seatno, int movieId)
        {
            //throw new NotImplementedException();
            string seats = seatno;
            string[] seatreserve = seats.Split(',');
            var seatnolist = _context.BookingTable.Where(a=>a.MovieDetailsId == movieId).ToList();
            foreach(var item in seatnolist)
            {
                string vekezakazano = item.seatno;
                foreach(var item1 in seatreserve)
                {
                    if (item1 == vekezakazano)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag == false)
                return true;
            else
                return false;
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