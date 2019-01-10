using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    //表示实体框架数据库上下文，并将处理创建、 读取、 更新和删除的操作
    public class MusicStoreEntities : DbContext
    {
        public DbSet<Album> Albums { get; set; } //专辑
        public DbSet<Genre> Genres { get; set; } //类型
    }
}