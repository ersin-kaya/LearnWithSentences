using System;
using Castle.DynamicProxy;
using DotNetBackendTemplate.Core.CrossCuttingConcerns.Caching;
using DotNetBackendTemplate.Core.Utilities.Interceptors;
using DotNetBackendTemplate.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBackendTemplate.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string[] _patterns;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(params string[] patterns)
        {
            _patterns = patterns;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_patterns);
        }
    }
}

