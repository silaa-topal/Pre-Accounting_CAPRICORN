using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
