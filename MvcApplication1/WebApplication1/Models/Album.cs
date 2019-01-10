using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Album //唱片
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; } //性别
        public int ArtistId { get; set; } //艺术家
        public string Title { get; set; } //名字
        public decimal Price { get; set; } //价格
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
    }
}