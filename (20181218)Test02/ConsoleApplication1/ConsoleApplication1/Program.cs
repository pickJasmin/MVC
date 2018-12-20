using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BusinessLayer;
using ConsoleApplication1.DataAccessLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //crateBlog();
            //QueryBlog();
            //Update();
            //Delete();
            AddPost();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
            //显示指定博客的帖子列表
            DisplayBlogIdByPost(blogId);
            //根据指定到博客信息创建新帖子

            //新建帖子
            Post post = new Post();
            
            //填写帖子的属性
            Console.WriteLine("请输入帖子标题");
            post.Title = Console.ReadLine();
            Console.WriteLine("请输入帖子内容");
            post.Content = Console.ReadLine();
            post.BlogId = blogId;
            //帖子通过数据库上下文新增
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
            //显示指定博客的帖子列表
            DisplayBlogIdByPost(blogId);

        }
        /// <summary>
        /// 用户选择某个博客（id）
        /// </summary>
        /// <returns></returns>

        static int GetBlogId()
        {
            //提示用户输入博客ID
            Console.WriteLine("请输入一个博客的ID");
            //获取用户输入，并入变量id
            int id = int.Parse(Console.ReadLine());
            //返回id
            return id;

        }
        /// <summary>
        /// 显示指定博客的帖子列表
        /// </summary>
        /// <param name="blogId"></param>
        static void DisplayBlogIdByPost(int blogId)
        {
            Console.WriteLine(blogId + "的帖子列表");
            List<Post> list = null;
            //根据博客ID获取博客
            //using是内部定义的内容，结束后会销毁，连接用完后关闭连接
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                //Console.WriteLine(blog.Name);
                //根据博客导航属性，获取所有该博客的帖子
                list = blog.Posts;
            }
            //遍历所有的帖子，显示帖子标题（博客号--帖子标题）
            foreach (var item in list)
            {
                Console.WriteLine("博客ID："+item.Blog.BlogId + "    " +"帖子标题："+ item.Title + "      " + "帖子内容：" +item.Content);
            }
        }

        //增加--交互
        static void crateBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);


        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.BlogId + " " + item.Name);
            }
        }
        //更改博客
        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新的名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);

        }
        //删除一个博客
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入一个博客到id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);

        }
    }
}
