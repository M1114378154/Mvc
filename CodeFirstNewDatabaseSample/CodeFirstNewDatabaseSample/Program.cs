using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BussinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program //界面层
    {
        static void Main(string[] args)
        {
            // crateBlog();
            //QueryBlog();
            //Update();
            //QueryBlog();
            //Delete();
            //AddPost();
            All();

            //DeletePost();
            //UpdatePost();
            //while (true)
            //{
            //    Console.Clear();
            Operation();
            //    All();
            //}

            //Console.WriteLine("按任意键退出");
            //Console.ReadKey();
        }

        static void All()
        {
            QueryBlog();
            Console.WriteLine("1--新增博客  2--删除博客   3-更新博客名  4-操作贴子  5-退出");
            int id = int.Parse(Console.ReadLine());
            if (id == 1)
            {
                crateBlog();
                Console.Clear();
                All();


            }
            else if (id == 2)
            {
                Delete();
                Console.Clear();
                All();
            }
            else if (id == 3)
            {
                Update();
                Console.Clear();
                All();
            }
            else if (id == 4)
            {
                Operation();
               
            }
            else if (id == 5)
            {
                return;
            }
            else
            {
                Console.WriteLine("请输入正确格式");
                All();
            }


        }

        //操作贴子
        static void Operation()
        {
            int id = GetBlogId();

                Console.Clear();
                //QueryBlog(); 
                DisplayPosts(id);
                Console.WriteLine("1--新增贴子  2--删除贴子   3-更新贴子  4-返回上一层  5-退出");
                int opId = int.Parse(Console.ReadLine());
                ////用户选择某个博客（id）
                //int blogId = GetBlogId();

                if (opId == 1)
                {
                    AddPost();
                    Console.Clear();
                    Operation();
                }
                else if (opId == 2)
                {
                    DeletePost();
                    Console.Clear();
                    Operation();
                }
                else if (opId == 3)
                {
                    UpdatePost();
                    Console.Clear();
                    Operation();
                }
                else if (opId == 4)
                {
                    All();
                }
                else if (opId == 5)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("请输入正确格式");
                    Operation();
                }

            }
        

        //新增贴子
        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
            //Console.WriteLine(blogId);
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
            //根据指定到博客信息创建新帖子   
            //新建贴子
            Post post = new Post();
            //填写贴子属性
            Console.WriteLine("请输入新贴子标题");
            post.Title = Console.ReadLine();
            Console.WriteLine("请输入新贴子内容");
            post.Content = Console.ReadLine();
            post.BlogId = blogId;
            //贴子通过数据库上下文新增
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }

            //显示指定博客的帖子列表
            DisplayPosts(blogId);
        }

        //删除贴子
        static void DeletePost()
        {
            QueryBlog();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            PostBussinessLayer pbl = new PostBussinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int id = int.Parse(Console.ReadLine());
            DisplayPosts(id);
            Console.WriteLine("请输入删除的贴子");
            int postId = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postId);
            pbl.DeletePost(post);
            DisplayPosts(id);
        }

        //更新贴子
        static void UpdatePost()
        {
            QueryBlog();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            PostBussinessLayer pbl = new PostBussinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int blogId = int.Parse(Console.ReadLine());
            DisplayPosts(blogId);
            Console.WriteLine("请输入修改的贴子ID");
            int postId = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postId);
            Console.WriteLine("请输入新标题");
            string newTitle = Console.ReadLine();
            post.Title = newTitle;
            Console.WriteLine("请输入新内容");
            string newContent = Console.ReadLine();
            post.Content = newContent;
            pbl.Update(post);
            DisplayPosts(blogId);
        }



        //用户选择某个博客(id)
        static int GetBlogId()
        {
            Console.WriteLine("请输入博客ID");
            //获取用户输入，并存入变量id
            int id = int.Parse(Console.ReadLine());
            return id;

        }

        //显示指定博客的帖子列表
        static void DisplayPosts(int blogId)
        {
            //Console.WriteLine(blogId + "的贴子列表");
            //创建一个列表（list 定义在外面 代码走出using后还能使用）
            List<Post> list = null;

            using (var db = new BloggingContext())
            {
                //根据博客ID获取博客（通过Find方法）
                Blog blog = db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客的贴子
                list = blog.Posts;
            }
            //遍历所有贴子（item代表贴子），显示贴子标题（博客号-贴子标题）
            foreach (var item in list)
            {
                Console.WriteLine("博客ID:{0} ---- 贴子标题:{1}  ---- 贴子内容:{2} ---- 贴子ID:{3}", item.BlogId, item.Title, item.Content, item.PostId);
            }


            //根据博客ID获取博客
            //BlogBusinessLayer bbl = new BlogBusinessLayer();
            //var blogs = bbl.Query(blogId);
            //foreach (var item in blogs)
            //{
            //    if (blogId == item.BlogId)
            //    {
            //        Console.WriteLine(item.Name);
            //        break;
            //    }

            //}

        }

        //根据指定的博客信息创建新帖子 
        //static void cratePost(int blogId)
        //{
        //    Console.WriteLine("请输入贴子名字");
        //    string title = Console.ReadLine();
        //    Console.WriteLine("请输入贴子内容");
        //    string content = Console.ReadLine();
        //    //填写贴纸属性
        //    Post post = new Post();
        //    post.BlogId = blogId;
        //    post.Title = title;
        //    post.Content = content;
        //    post.BlogId = blogId;
        //}
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
                Console.WriteLine(item.BlogId + " " + item.Name);
            }
        }

        static void Update()
        {
            Console.WriteLine("请输入ID");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }

        //删除博客
        static void Delete()
        {

            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入删除id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }




    }
}
