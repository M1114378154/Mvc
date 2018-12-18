using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BussinessLayer
{
    public class BlogBusinessLayer//业务层
    {
        public void Add(Blog blog)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Blogs.Add(blog);
                //db.Entry(Blog).State = EntityState.Added;
                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.ToList();

             }    
        }

        //根据ID查询
        public Blog Query(int id)
        {
            //使用上下文对象
            using (var db = new BloggingContext())
            {
                //调用Find(id)返回Blogs
               return db.Blogs.Find(id);
            }
        }

        public void Update(Blog blog)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //用枚举来表示修改状态
                db.Entry(blog).State = EntityState.Modified;
                //保存状态改变
                db.SaveChanges();
            }
        }
    }
}