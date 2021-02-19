using System;
using SimpleInjector;

namespace AndroidTelecomSample.Services
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Container container = new Container();

        public static ServiceLocator Instance { get; } = new ServiceLocator();

        public bool IsLocked => this.container.IsLocked;

        private ServiceLocator()
        {
            this.container.Register<IServiceLocator>(() => this, Lifestyle.Singleton);
        }

        public object GetInstance(Type type)
        {
            return this.container.GetInstance(type);
        }

        public T GetInstance<T>() where T : class
        {
            return this.container.GetInstance<T>();
        }

        public void Register<TService, TImplementation>(ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService
        {
            var lifestyle = GetLifestyle(lifetime);
            this.container.Register<TService, TImplementation>(lifestyle);
        }

        private Lifestyle GetLifestyle(ServiceLifetime lifetime)
        {
            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                    return Lifestyle.Transient;
                case ServiceLifetime.Singleton:
                default:
                    return Lifestyle.Singleton;
            }
        }

        public void Register<TService>(ServiceLifetime lifetime)
            where TService : class
        {
            var lifestyle = GetLifestyle(lifetime);
            this.container.Register<TService>(lifestyle);
        }

        public void Register<TService>(Func<TService> creator, ServiceLifetime lifetime)
            where TService : class
        {
            var lifestyle = GetLifestyle(lifetime);
            this.container.Register<TService>(creator, lifestyle);
        }

        public void Verify()
        {
            this.container.Verify();
        }
    }
}