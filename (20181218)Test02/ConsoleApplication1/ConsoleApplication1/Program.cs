using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BusinessLayer;
using ConsoleApplication1.DataAccessLayer;
using System.Data.Entity;

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
            //AddPost();
            //DeletePost();
            //UpdatePost();
            //DeleteBlogByPost();
            //OpenBegin();
            SelectPost();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void OpenBegin()
        {
            Console.WriteLine("\n请选择您要的操作:  1-博客操作   2-帖子操作   3-退出");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                OpenBlog();
            }
            else if (number == 2)
            {
                OpenPost();
                OpenBegin();
            }
            else if (number == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("对不起,您输入了无效的操作!");
                OpenBlog();
            }
            Console.WriteLine("点任意件,退出!");
            Console.Read();
        }



        /// <summary>
        /// 博客的操作
        /// </summary>
        static void OpenBlog()
        {
            Console.Clear();
            QueryBlog();
            Console.WriteLine("\n请选择您要的操作: 1-新增博客   2-修改博客   3-删除博客   4-帖子列表  5-返回");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                CrateBlog();
                QueryBlog();
                OpenBegin();
            }
            else if (number == 2)
            {
                UpdateBlog();
                QueryBlog();
                OpenBegin();
            }
            else if (number == 3)
            {
                Console.WriteLine("\n您是否要删除博客  1-是   2-我在想想");
                int num = int.Parse(Console.ReadLine());
                if (num == 1)
                {
                    DeleteBlog();
                    QueryBlog();
                    OpenBegin();
                }
                else if (num == 2)
                {
                    OpenBegin();
                }

            }
            else if (number == 4)
            {
                OpenPost();
            }
            else if (number == 5)
            {
                OpenBegin();
            }
            else
            {
                Console.WriteLine("对不起,您输入了无效的操作!");
            }

        }



        /// <summary>
        /// 帖子的操作
        /// </summary>
        static void OpenPost()
        {
            Console.Clear();
            CrateBlog();
            Console.WriteLine("\n请选择您要的操作: 1-新增帖子   2-修改帖子   3-删除帖子   4-返回");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                CratePost();
                QueryBlog();
                OpenBlog();
            }
            else if (number == 2)
            {
                UpdatePost();
                QueryBlog();
                OpenBlog();
            }
            else if (number == 3)
            {
                DeletePost();
                QueryBlog();
                OpenBlog();
            }
            else if (number == 4)
            {
                OpenBlog();
            }
        }



        static void SelectPost()
        {
            Console.WriteLine("请输入你要查询的帖子");
            string name = Console.ReadLine();
            PostBusinessLayer pbl = new PostBusinessLayer();
            var query = pbl.SelectPostTitle(name);
            foreach(var item in query)
            {
                Console.WriteLine(item.Title + "    " + item.Content);
            }
        }



        /// <summary>
        /// 更改帖子内容
        /// </summary>
        static void UpdatePost()
        {
            QueryBlog();

            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine(" 请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayBlogIdByPost(blogID);


            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("请输入您要修改的，帖子的ID：");
            int postId = int.Parse(Console.ReadLine());

            Post post = pbl.Query(postId);
            Console.WriteLine("请输入您要修改的标题:");
            string postTitle = Console.ReadLine();
            post.Title = postTitle;

            Console.WriteLine("请输入您要修改的内容:");
            string postContent = Console.ReadLine();
            post.Content = postContent;
            pbl.Update(post);

            DisplayBlogIdByPost(blogID);


        }
        /// <summary>
        /// 删除一个帖子
        /// </summary>
        static void DeletePost()
        {

            //显示所有博客列表
            QueryBlog();

            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine(" 请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayBlogIdByPost(blogID);

            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("请输入一个帖子的id");
            int postid = int.Parse(Console.ReadLine());


            Post post = pbl.Query(postid);
            pbl.Delete(post);
            Console.WriteLine("删除成功！");


        }
        /// <summary>
        /// 显示添加某个博客的帖子
        /// </summary>
        static void CratePost()
        {
            Post post = new Post();
            Console.WriteLine("请用户输入ID");
            post.BlogId = int.Parse(Console.ReadLine());

            Console.WriteLine("请用户输入标题");
            post.Title = Console.ReadLine();

            Console.WriteLine("请用户输入内容");
            post.Content = Console.ReadLine();
            PostBusinessLayer pbl = new PostBusinessLayer();
            pbl.Add(post);
            DisplayBlogIdByPost(post.BlogId);

            ////显示博客列表
            //QueryBlog();
            ////用户选择某个博客（id）
            //int blogId = GetBlogId();
            ////显示指定博客的帖子列表
            //DisplayBlogIdByPost(blogId);
            ////根据指定到博客信息创建新帖子
            ////新建帖子
            //Post post = new Post();
            ////填写帖子的属性
            //Console.WriteLine("请输入帖子标题");
            //post.Title = Console.ReadLine();
            //Console.WriteLine("请输入帖子内容");
            //post.Content = Console.ReadLine();
            //post.BlogId = blogId;
            ////帖子通过数据库上下文新增
            //using (var db = new BloggingContext())
            //{
            //    db.Posts.Add(post);
            //    db.SaveChanges();
            //}
            ////显示指定博客的帖子列表
            //DisplayBlogIdByPost(blogId);

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
                Console.WriteLine("博客ID：" + item.Blog.BlogId + "    " + "帖子标题：" + item.Title + "      " + "帖子内容：" + item.Content + "      " + "帖子ID：" + item.PostId);
            }
        }







        /// <summary>
        /// 博客增加--交互
        /// </summary>
        static void CrateBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);


        }
        /// <summary>
        /// 显示全部博客
        /// </summary>
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.BlogId + " " + item.Name);
            }
        }
        /// <summary>
        /// 更改博客
        /// </summary>
        static void UpdateBlog()
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
        /// <summary>
        /// 删除一个博客
        /// </summary>
        static void DeleteBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入一个博客到id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);

        }
    }
}
