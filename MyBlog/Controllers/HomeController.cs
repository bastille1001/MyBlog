using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Repository;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repo;

        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var posts = repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = repo.GetPost(id);
            return View(post);
        }
    }
}
