using System.Web;
using System.Web.Mvc;

namespace NQHuy_Project2_2210900105
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
