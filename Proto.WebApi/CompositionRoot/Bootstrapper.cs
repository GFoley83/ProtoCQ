using System;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web.Mvc;
using Proto.Domain.QueryHandlers;

namespace Proto.WebApi.CompositionRoot
{
    public static class Bootstrapper
    {
        private static Container container;

        public static object GetInstance(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public static T GetInstance<T>() where T : class
        {
            return container.GetInstance<T>();
        }

        public static void Bootstrap()
        {
            container = new Container();

            DomainBootstrapper.Bootstrap(container);

            RegisterWcfSpecificDependencies();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));

            container.Verify();
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

            container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), Assembly.GetExecutingAssembly());
        }
    }
}