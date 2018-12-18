using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.DataAccessLayer;
using System.Data.Entity;

namespace ConsoleApplication1.BusinessLayer
{
    /// <summary>
    /// 博客的业务类
    /// </summary>
    public class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Blogs.Add(blog);
                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
                return db.Blogs.ToList();
            }
        }
        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void Update(Blog blog)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Entry(blog).State = EntityState.Modified;
                //保存状态改变
                db.SaveChanges();
            }

        }
    }
}
