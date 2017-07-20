using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using SimpleCqrs;

namespace ALS.CQRS.Web
{
    public class MyServiceLocator
        : SimpleCqrs.IServiceLocator
    {
        [NotNull]
        private readonly Microsoft.Extensions.DependencyInjection.ServiceProvider m_ServiceProvider;

        public MyServiceLocator(
            [NotNull] ServiceProvider serviceProvider)
        {
            m_ServiceProvider = serviceProvider;
        }

        public void Dispose()
        {
        }

        public T Resolve <T>()
            where T : class
        {
            return m_ServiceProvider.GetService<T>();
        }

        public T Resolve <T>(string key)
            where T : class
        {
            return m_ServiceProvider.GetService(key);
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public IList <T> ResolveServices <T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public void Register <TInterface>(Type implType)
            where TInterface : class
        {
            throw new NotImplementedException();
        }

        public void Register <TInterface, TImplementation>()
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void Register <TInterface, TImplementation>(string key)
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void Register(string key,
                             Type type)
        {
            throw new NotImplementedException();
        }

        public void Register(Type serviceType,
                             Type implType)
        {
            throw new NotImplementedException();
        }

        public void Register <TInterface>(TInterface instance)
            where TInterface : class
        {
            throw new NotImplementedException();
        }

        public void Release(object instance)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public TService Inject <TService>(TService instance)
            where TService : class
        {
            throw new NotImplementedException();
        }

        public void TearDown <TService>(TService instance)
            where TService : class
        {
            throw new NotImplementedException();
        }

        public void Register <TInterface>(Func <TInterface> factoryMethod)
            where TInterface : class
        {
            throw new NotImplementedException();
        }
    }
}