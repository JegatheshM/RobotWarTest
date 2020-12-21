using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using RobotBusiness.Implementation;
using RobotBusiness.Interface;

namespace RobotWarTest
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            
            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterType<FindPositionBo>().As<IFindPositionBo>().InstancePerRequest();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}