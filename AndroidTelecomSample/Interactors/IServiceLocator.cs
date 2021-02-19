using System;

namespace AndroidTelecomSample.Services
{
    public interface IServiceLocator
    {
        bool IsLocked { get; }

        object GetInstance(Type type);
        T GetInstance<T>() where T : class;

        void Register<TService, TImplementation>(ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService;

        void Register<TService>(ServiceLifetime lifetime)
            where TService : class;

        void Register<TService>(Func<TService> creator, ServiceLifetime lifetime)
            where TService : class;
    }
}