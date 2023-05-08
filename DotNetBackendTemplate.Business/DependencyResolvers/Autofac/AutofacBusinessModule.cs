using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Business.Concrete;
using DotNetBackendTemplate.Core.Utilities.Interceptors;
using DotNetBackendTemplate.Core.Utilities.Security.JWT;
using DotNetBackendTemplate.DataAccess.Abstract;
using DotNetBackendTemplate.DataAccess.Concrete.EntityFramework;

namespace DotNetBackendTemplate.Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfSomeFeatureEntityDal>().As<ISomeFeatureEntityDal>().SingleInstance();
            builder.RegisterType<SomeFeatureEntityManager>().As<ISomeFeatureEntityService>().SingleInstance();

            builder.RegisterType<AccountManager>().As<IAccountService>();
            builder.RegisterType<EfAccountDal>().As<IAccountDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

