using System.Web;
using System.Web.Mvc;

namespace Tp8___DealOrNoDeal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
