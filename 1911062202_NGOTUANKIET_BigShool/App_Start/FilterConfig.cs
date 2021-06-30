using System.Web;
using System.Web.Mvc;

namespace _1911062202_NGOTUANKIET_BigShool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
