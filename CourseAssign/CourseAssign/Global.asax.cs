using CourseAssign.Core.Services;
using CourseAssign.Core.Services.Interfaces;
using CourseAssign.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;

namespace CourseAssign
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Database.SetInitializer<courseassignDbContext>(new DropCreateDatabaseIfModelChanges<courseassignDbContext>());

            IUnityContainer container = new UnityContainer();

            container.RegisterType<ITeacherService, TeacherService>();
           

            container.RegisterType<DbContext, courseassignDbContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        }
    }
}
