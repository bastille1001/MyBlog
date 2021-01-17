using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Repository;
using MyBlog.Models;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View(new Post());
            else
            {
                var post = repo.GetPost((int)id);
                return View(post);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post p)
        {
            if (p.Id > 0)
                repo.UpdatePost(p);
            else
                repo.AddPost(p);

            if (await repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            repo.RemovePost(id);
            await repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
