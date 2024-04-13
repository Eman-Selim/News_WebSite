using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FirstCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewsContext _context;
        public HomeController(ILogger<HomeController> logger, NewsContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index()
        {
            var result=_context.Categories.ToList();
            return View(result);
        }
        public IActionResult Contact()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult SaveContact(ContactUs model)
        {
            _context.Contacts.Add(model);
            _context.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult Messages()
        {
            return View(_context.Contacts.ToList());
        }

        public IActionResult News( int id )
        {
            Category c = _context.Categories.Find(id);
            ViewBag.cat = c.Name;

            var result=_context.News.Where(y => y.CategoryId == id).OrderByDescending(x=>x.Date).ToList();
            return View(result);
        }
        public IActionResult NewsDelete(int id)
        {
            var news = _context.News.Find(id);
            _context.Remove(news);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
