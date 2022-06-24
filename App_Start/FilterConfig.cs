using System.Web;
using System.Web.Mvc;

namespace HPIMS_MVC_SignalR_Integrated
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
