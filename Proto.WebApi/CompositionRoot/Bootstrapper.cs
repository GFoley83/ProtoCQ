using System;
using System.Reflection;
using System.Web.Http;
using Proto.Data;
using Proto.Domain.QueryHandlers;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Proto.WebApi.CompositionRoot
{
    public static class Bootstrapper
    {
        private static Container _container;

        public static object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public static T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public static void Bootstrap(HttpConfiguration config)
        {
            _container = new Container();

            var assemblies = new[]
                             {
                                 typeof(IQueryHandler<,>).Assembly,
                                 typeof(IClientManagementContext).Assembly
                             };

            _container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            _container.Register<ClientManagementContext>(Lifestyle.Scoped);

            _container.Register(typeof(IQueryHandler<,>), assemblies);

            // This is an extension method from the integration package.
            _container.RegisterWebApiControllers(config, Assembly.GetExecutingAssembly());

            RegisterWcfSpecificDependencies();


            //            DependencyResolver.SetResolver(
            //                new SimpleInjectorDependencyResolver(container));


            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);


            _container.Verify();
        }

        private static void RegisterWcfSpecificDependencies()
        {
            //container.RegisterSingle<ILogger, DebugLogger>();
        }
    }

    public static class DomainBootstrapper
    {
        public static void Bootstrap(Container container)
        {
            //if (container == null)
            //{
            //    throw new ArgumentNullException("container");
            //}

            //container.RegisterSingle<IValidator>(new DataAnnotationsValidator(container));

            //container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), Assembly.GetExecutingAssembly());
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));

            //container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), Assembly.GetExecutingAssembly());

            container.Register(typeof(IQueryHandler<,>), new[] {typeof(IQueryHandler<,>).Assembly});
        }
    }
}