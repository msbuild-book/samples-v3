using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace SampleWeb {
    public static class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.EnableFriendlyUrls();
        }
    }
}
