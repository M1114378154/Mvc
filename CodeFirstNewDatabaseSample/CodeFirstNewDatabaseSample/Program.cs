using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BussinessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program //界面层
    {
        static void Main(string[] args)
        {
           // crateBlog();
            QueryBlog();
            Update();
            QueryBlog();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        //增加---交互
        static void crateBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            //接收用户输入传给name
            string name = Console.ReadLine();
            //创建博客对象
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
                Console.WriteLine(item.BlogId + " "+ item.Name);
            }
        }

        static void Update()
        {
            Console.WriteLine("请输入ID");
            int id=int.Parse( Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
             Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
    }
}
