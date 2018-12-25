using ConsoleApplication1.DataAccessLayer;
using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.BusinessLayer
{
    public class PostBusinessLayer
    {
        public void Add(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
        public void Delete(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public Post Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }
        public void Update(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
      
        public List<Post> SelectPostTitle(string title)
        {
            using (var db = new BloggingContext())
            {
                var query = from p in db.Posts
                            where p.Title.Contains(title)
                            select p;
                return query.ToList();
            }
        }
    }
}
