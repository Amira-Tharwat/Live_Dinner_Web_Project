using Live_Dinner_3.Data;
using Live_Dinner_3.Models;
using Live_Dinner_3.Utility;
using Live_Dinner_3.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Live_Dinner_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        public HomeController(ILogger<HomeController> logger , ApplicationDbContext dbcontext)
        {
            _logger = logger;
            _dbcontext= dbcontext;
        }
		#region Index
		public IActionResult Index()
        {
            return View();
        }
		#endregion

		#region Menu
		public IActionResult Menu( int ?Page )
            
        {
            if (Page == null)
            {
                Page = 1;
            }
            int NoOfSkipMeals = (int)(Page - 1) * 15;
            var meals = _dbcontext.meals.Include(m => m.Chef).Skip(NoOfSkipMeals).Take(15).ToList();
            var allMeals = new MenuViewModel()
            {
                Meals = meals,
                CurrentPage = (int)Page,
                PageCount = (int)Math.Ceiling(_dbcontext.meals.Count() / 15.0)
            };
            return View(allMeals);
        }
		#endregion

		#region About
		public IActionResult About()
        {
            return View();
        }
		#endregion




		#region AddContactMessage
		public IActionResult AddContactMessage()
		{
            
			return View( );
		}

        [HttpPost]
		public IActionResult AddContactMessage([FromForm] ContactMessage Model)
		{

            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbcontext.contactMessages.Add(Model);
			_dbcontext.SaveChanges();
             
            return RedirectToAction("Index");
		}
		#endregion
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
