using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Edit(Post p)
        {
            return RedirectToAction("Index");
        }
    }
}
