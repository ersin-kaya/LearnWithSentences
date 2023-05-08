using System;
using System.Diagnostics;
using DotNetBackendTemplate.Core.CrossCuttingConcerns.Caching;
using DotNetBackendTemplate.Core.CrossCuttingConcerns.Caching.Microsoft;
using DotNetBackendTemplate.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBackendTemplate.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}

