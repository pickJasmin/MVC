﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.DataAccessLayer
{
    /// <summary>
    /// 上下文类
    /// </summary>
    class BloggingContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
