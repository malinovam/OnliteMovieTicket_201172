using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTickets.Data;
using OnlineMovieTickets.Models;
using OnlineMovieTickets.Models.ViewModels;

namespace OnlineMovieTickets.Controllers
{
    public class CardController : Controller
    {
        private UserManager<ApplicationUser> _usermanager;
        private ApplicationDbContext _context;

        public CardController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            var item = _context.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            return View(item);
        }
        public IActionResult prazna()
        {
            TempData["cartempty"]= "Empty Cart";
            return View();
        }
        [HttpGet]
        public IActionResult proceed(Cart cart)
        {
            var CartList = _context.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            if (CartList.Count == 0) {
                return RedirectToAction("prazna","Card");
            }
            else
            {
                return View(CartList);
            }
        }
    }
}
