using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsViewTemplateDemoCrud
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //   name: "studentById",
            //   url: "students/{id}",
            //   defaults: new { controller = "Student", action = "GetStudentById", id = 1 },
            //    constraints: new { id = @"\d+" }
            //   );

            //routes.MapRoute(
            //   name: "GetAddressOfStudentById",
            //   url: "students/{id}/address",
            //   defaults: new { controller = "Student", action = "GetAddressOfStudentById" },
            //   constraints: new { id = @"\d+" }
            //   );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "GetAllStudents", id = UrlParameter.Optional }
            );
        }
    }
}
