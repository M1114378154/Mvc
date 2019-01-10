using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity
{
    public class FilterConfig
    {
        //授权特性加在全局
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }

    }
}

