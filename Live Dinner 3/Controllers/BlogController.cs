using Live_Dinner_3.Data;
using Live_Dinner_3.Models;
using Live_Dinner_3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Live_Dinner_3.Controllers
{
    public class BlogController(ApplicationDbContext _dbcontext) : Controller
    {

        public IActionResult ViewAllBlogs()
        {
            var blogs = _dbcontext.blogs.ToList();
            return View(blogs);

        }
        public IActionResult BlogDetails(int id)
        {

            var blogcom = new BlogCommentsViewModel()
            {
                blog = _dbcontext.blogs.Include(b => b.Comments).SingleOrDefault(b => b.Id == id)
            };
            return View(blogcom);
        }
		public IActionResult AddComment(comment comment)
		{
            if (!ModelState.IsValid)
            {
                return View();
            }
            var blog =_dbcontext.blogs.Include(b => b.Comments).SingleOrDefault(b => b.Id == comment.BlogId);
            blog.Comments.Add(comment);
            _dbcontext.blogs.Update(blog);
            _dbcontext.SaveChanges();
           
			return View("ViewAllBlogs" , _dbcontext.blogs.Include(b=>b.Comments).ToList());

		}
	}
}
