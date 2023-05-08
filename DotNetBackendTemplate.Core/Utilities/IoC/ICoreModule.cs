using System;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBackendTemplate.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}

