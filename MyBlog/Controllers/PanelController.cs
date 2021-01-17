using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Repository;
using MyBlog.Models;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IRepository repo;
        public PanelController(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var posts = repo.GetAllPosts();
            return View(posts);
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
