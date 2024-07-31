using Live_Dinner_3.Data;
using Live_Dinner_3.Models;
using Live_Dinner_3.Utility;
using Live_Dinner_3.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Live_Dinner_3.Controllers
{

    [Authorize(Roles = "Admin ,Employee")]
    public class DashBoardController : Controller
    {

       
        private readonly ApplicationDbContext _dbcontext;
        private readonly IHostingEnvironment _hosting;

        [Obsolete]
        public DashBoardController(ApplicationDbContext dbcontext , IHostingEnvironment hosting)
        {
            _dbcontext = dbcontext;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            return View();
        }




        #region AddChef
        [Authorize(Roles = "Admin ")]
        public IActionResult AddChef() {
           

            return View(); 
        }
        [HttpPost]
        [Authorize(Roles = "Admin ")]
        public IActionResult AddChef(Chef chef)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (chef.ChefImg != null)
            {
                string ImgFolder = Path.Combine(_hosting.WebRootPath, "MyImages");
                string ImgPath = Path.Combine(ImgFolder, chef.ChefImg.FileName);
                chef.ChefImg.CopyTo(new FileStream(ImgPath, FileMode.Create));
                chef.ImgPath = chef.ChefImg.FileName;
            }
            _dbcontext.chefs.Add(chef);
            _dbcontext.SaveChanges();
            
            return RedirectToAction("Index");
        }
        #endregion

        #region ViewChefs
        [HttpGet]
        public IActionResult ViewChefs() {
            var chefs = _dbcontext.chefs.ToList();  
            return View(chefs);
        
        }
        #endregion


        #region DeleteChef
        [Authorize(Roles = "Admin ")]
        public IActionResult DeleteChef(int id) { 

            Chef? chef = _dbcontext.chefs.FirstOrDefault(c=>c.Id== id);
            _dbcontext.chefs.Remove(chef);
            _dbcontext.SaveChanges(); 
            return RedirectToAction("ViewChefs");
        }
        #endregion


        #region EditChef
        [Authorize(Roles = "Admin ")]
        public IActionResult EditChef(int id) {  
            Chef? chef=_dbcontext.chefs.FirstOrDefault(c=>c.Id == id);
            
            return View(chef);
        }
        [HttpPost]
        [Authorize(Roles = "Admin ")]
        public IActionResult EditChef(Chef chef)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Chef oldchef=_dbcontext.chefs.SingleOrDefault(c=>c.Id== chef.Id);
            oldchef.Name= chef.Name;
            oldchef.Email= chef.Email;
            oldchef.ChefImg= chef.ChefImg;
           
            if (!ModelState.IsValid)
            {
                return View(oldchef);
            }
            if (chef.ChefImg != null)
            {
                string ImgFolder = Path.Combine(_hosting.WebRootPath, "MyImages");
                string ImgPath = Path.Combine(ImgFolder, chef.ChefImg.FileName);
                chef.ChefImg.CopyTo(new FileStream(ImgPath, FileMode.Create));
                oldchef.ImgPath = chef.ChefImg.FileName;
            }
            _dbcontext.chefs.Update(oldchef);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion


        #region AddMeal
        [Authorize(Roles = "Admin ")]
        public IActionResult AddMeal()
        {
            var chefs = new MealViewModel()
            {
                chefs = _dbcontext.chefs.Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };
            return View(chefs);
           
        }
        [HttpPost]
        [Authorize(Roles = "Admin ")]
        public IActionResult AddMeal(Meal meal)
        {
            

            if (!ModelState.IsValid)
            {
                var meal1 = new MealViewModel()
                {
                    meal = meal,
                    chefs = _dbcontext.chefs.Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                };
                return View(meal1);
              
            }
            if (meal.MealImg != null)
            {
                string ImgFolder = Path.Combine(_hosting.WebRootPath, "MyImages");
                string ImgPath = Path.Combine(ImgFolder, meal.MealImg.FileName);
                meal.MealImg.CopyTo(new FileStream(ImgPath, FileMode.Create));
                meal.ImgPath = meal.MealImg.FileName;
            }
            _dbcontext.meals.Add(meal);
            _dbcontext.SaveChanges();
           
            return RedirectToAction("Index");
        }

        #endregion

        #region ViewMeals
        [HttpGet]
        public IActionResult ViewMeals()
        {
            var meals=_dbcontext.meals.Include(m=>m.Chef).ToList();
            return View(meals);

        }
        #endregion


        #region DeleteMeal
        [Authorize(Roles = "Admin ")]
        public IActionResult DeleteMeal(int id)
        {

           Meal? meal = _dbcontext.meals.FirstOrDefault(m => m.Id == id);
            _dbcontext.meals.Remove(meal);
            _dbcontext.SaveChanges();
            return RedirectToAction("ViewMeals");
        }
        #endregion


        #region EditMeal
        [Authorize(Roles = "Admin ")]
        public IActionResult EditMeal(int id)
        {
            Meal meal = _dbcontext.meals.FirstOrDefault(m => m.Id == id);
            var viewmeal = new MealViewModel()
            {
                meal=meal,
                chefs = _dbcontext.chefs.Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };

            return View(viewmeal);
        }
        [HttpPost]
        [Authorize(Roles = "Admin ")]
        public IActionResult EditMeal(Meal meal)
        {
            Meal oldmeal = _dbcontext.meals.SingleOrDefault(m => m.Id == meal.Id);
            oldmeal.Name= meal.Name;
            oldmeal.Price= meal.Price;
            oldmeal.Description= meal.Description;
            oldmeal.Availability = meal.Availability;
            oldmeal.MealImg= meal.MealImg;
            oldmeal.Type= meal.Type;
            oldmeal.ChefId= meal.ChefId;
            if (!ModelState.IsValid)
            {
                return View(oldmeal);
            }
            if (meal.MealImg != null)
            {
                string ImgFolder = Path.Combine(_hosting.WebRootPath, "MyImages");
                string ImgPath = Path.Combine(ImgFolder, meal.MealImg.FileName);
                meal.MealImg.CopyTo(new FileStream(ImgPath, FileMode.Create));
                oldmeal.ImgPath = meal.MealImg.FileName;
            }
            _dbcontext.meals.Update(oldmeal);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion


        #region AddBlog
       
        public IActionResult AddBlog()
        {
            
            return View();
        }
        [HttpPost]
       
        public IActionResult AddBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (blog.BlogImg != null)
            {
                string ImgFolder = Path.Combine(_hosting.WebRootPath, "MyImages");
                string ImgPath = Path.Combine(ImgFolder, blog.BlogImg.FileName);
                blog.BlogImg.CopyTo(new FileStream(ImgPath, FileMode.Create));
                blog.ImgPath = blog.BlogImg.FileName;
            }
            _dbcontext.Add(blog);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region ViewBlogs
        [HttpGet]
        public IActionResult ViewBlogs ()
        {
            var blogs=_dbcontext.blogs.ToList();
            return View(blogs);

        }
        #endregion

        #region ViewComments

        [HttpGet]
        public IActionResult ViewComments(int id)
        {
            var blog = _dbcontext.blogs.Include(b => b.Comments).FirstOrDefault(b => b.Id == id);
            return View(blog);

        }

        #endregion


        #region DeleteComment
        public IActionResult DeleteComment(int id , int comid)
        {

            var blog = _dbcontext.blogs.Include(b=>b.Comments).FirstOrDefault(b => b.Id == id);
               var comment= blog.Comments.FirstOrDefault(b => b.Id==comid);
            _dbcontext.Remove(comment);
            _dbcontext.SaveChanges();
            return RedirectToAction("ViewBlogs");
        }

        #endregion

        #region DeleteBlog
       
        public IActionResult DeleteBlog(int id)
        {

            Blog? blog = _dbcontext.blogs.FirstOrDefault(b => b.Id == id);
            _dbcontext.blogs.Remove(blog);
            _dbcontext.SaveChanges();
            return RedirectToAction("ViewBlogs");
        }
        #endregion

        #region EditBlog
       
        public IActionResult EditBlog(int id)
        {
            Blog blog = _dbcontext.blogs.FirstOrDefault(b => b.Id == id);
           
            return View(blog);
        }
        [HttpPost]
       
        public IActionResult EditBlog(Blog blog)
        {
            Blog oldblog = _dbcontext.blogs.SingleOrDefault(b => b.Id == blog.Id);

            oldblog.Title= blog.Title;
            oldblog.Description= blog.Description;
            oldblog.Author= blog.Author;
            oldblog.BlogImg = blog.BlogImg;
            if (!ModelState.IsValid)
            {
                return View(oldblog);
            }
            if (blog.BlogImg != null)
            {
                string ImgFolder = Path.Combine(_hosting.WebRootPath, "MyImages");
                string ImgPath = Path.Combine(ImgFolder, blog.BlogImg.FileName);
                blog.BlogImg.CopyTo(new FileStream(ImgPath, FileMode.Create));
                oldblog.ImgPath = blog.BlogImg.FileName;
            }
            _dbcontext.blogs.Update(oldblog);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region ViewReservations
        [HttpGet]
        [Authorize(Roles = "Admin ,Employee")]
        public IActionResult ViewReservations()
		{
			var reservations = _dbcontext.reservations.ToList();
			return View(reservations);

		}
        #endregion


        #region ViewMessages
        [HttpGet]
        
        public IActionResult ViewMessages()
        {
            var messages = _dbcontext.contactMessages.ToList();
            return View(messages);

        }
        #endregion

       
       


    }
}
