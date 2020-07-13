using System.Web;
using System.Web.Mvc;

namespace Session8_LibraryManagementUIMysqlEF6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
