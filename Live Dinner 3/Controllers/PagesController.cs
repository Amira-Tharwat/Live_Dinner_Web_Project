using Live_Dinner_3.Data;
using Live_Dinner_3.Models;
using Live_Dinner_3.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Live_Dinner_3.Controllers
{
    public class PagesController (ApplicationDbContext _dbcontext): Controller
    {
        #region Stuff
        public IActionResult Stuff(int ?Page)
        {
            if (Page == null)
            {
                Page = 1;
            }
            int NoOfSkipChefs = (int)(Page - 1) * 6;
            var chefs = _dbcontext.chefs.Skip(NoOfSkipChefs).Take(6).ToList();
            var allChefs = new StuffViewModel()
            {
                Chefs = chefs,
                CurrentPage = (int)Page,
                PageCount = (int)Math.Ceiling(_dbcontext.chefs.Count() / 6.0)
            };
            return View(allChefs);

        }

        #endregion

        #region Gallery

        public IActionResult Gallery(int? Page)

        {
            if (Page == null)
            {
                Page = 1;
            }
            int NoOfSkipImages = (int)(Page - 1) * 6;
            var images = _dbcontext.meals.Skip(NoOfSkipImages).Take(6).ToList();
            var allimages = new MenuViewModel()
            {
                Meals = images,
                CurrentPage = (int)Page,
                PageCount = (int)Math.Ceiling(_dbcontext.meals.Count() / 6.0)
            };
            return View(allimages);
        }

		#endregion


		#region Reservation

		[Authorize]
		public IActionResult AddReservation()
		{


			return View();
		}
		[HttpPost]

		[Authorize]
		public IActionResult AddReservation(Reservation reservation)
		{
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbcontext.reservations.Add(reservation);
			_dbcontext.SaveChanges();

			return RedirectToAction("Index", "Home");
		}
		#endregion


	}
}
