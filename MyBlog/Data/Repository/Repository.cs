using MyBlog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext context;
        
        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddPost(Post post)
        {
            context.Posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return context.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            context.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            context.Posts.Update(post);
        }


        public async Task<bool> SaveChangesAsync()
        {
            if(await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
