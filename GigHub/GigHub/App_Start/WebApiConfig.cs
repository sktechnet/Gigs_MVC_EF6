using System.Web.Http;

namespace GigHub
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
             new { id = RouteParameter.Optional });
        }

    }
}