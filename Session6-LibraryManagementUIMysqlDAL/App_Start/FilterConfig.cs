using System.Web;
using System.Web.Mvc;

namespace Session6_LibraryManagementUIMysqlDAL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
