﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeFirstNewDatabaseSample.Models
{
    public class Post
    {

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //相当于数据库外码（外键）
        public int BlogId { get; set; }
        //导航属性--目的是能够通过贴子对象访问对应的博客
        public virtual Blog Blog { get; set; }
    }
}
