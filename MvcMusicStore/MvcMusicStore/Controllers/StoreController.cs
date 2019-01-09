using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        public string Index()
        {
            return "Hello from Store.Index()";
        }
        //
        // GET: /Store/浏览
        //GET: /Store/Browse? genre = Disco
        public string Browse(string genre)
        {
            string message = HttpUtility.HtmlEncode("Store.Browse, Genre = "+ genre);

            return message;
        }
        //
        // GET: /Store/详细信息
        //GET: /Store/Details/5（ID）
        public string Details(int id)
        {
            string message = "Store.Details, ID = " + id;
            return message;
        }
    }
}