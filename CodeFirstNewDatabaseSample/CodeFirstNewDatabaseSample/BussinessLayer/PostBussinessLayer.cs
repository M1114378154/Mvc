using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample.BussinessLayer
{
  public  class PostBussinessLayer
    {
        public List<Post> Query(int blogId)
        {
            using(var db=new BloggingContext())
            {
                //根据博客id获取博客
                Blog blog = db.Blogs.Find(blogId);
                var list = blog.Posts;
                return list;
            }
        }

    }
}
