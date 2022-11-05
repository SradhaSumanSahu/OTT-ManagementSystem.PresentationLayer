using System.Web;
using System.Web.Mvc;

namespace OTT_ManagementSystem.PresentationLayer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
