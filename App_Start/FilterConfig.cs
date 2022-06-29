using System.Web;
using System.Web.Mvc;

namespace Melissa_Scott_9189_SA2_IPG521_Final
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
