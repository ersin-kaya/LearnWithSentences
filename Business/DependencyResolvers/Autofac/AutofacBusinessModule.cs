using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.AccountProvider;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfSomeFeatureEntityDal>().As<ISomeFeatureEntityDal>().SingleInstance();
            builder.RegisterType<SomeFeatureEntityManager>().As<ISomeFeatureEntityService>().SingleInstance();

            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();
            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();

            builder.RegisterType<EfFolderDal>().As<IFolderDal>().SingleInstance();
            builder.RegisterType<FolderManager>().As<IFolderService>().SingleInstance();

            builder.RegisterType<EfStudySetDal>().As<IStudySetDal>().SingleInstance();
            builder.RegisterType<StudySetManager>().As<IStudySetService>().SingleInstance();

            builder.RegisterType<EfAccountDal>().As<IAccountDal>();
            builder.RegisterType<AccountManager>().As<IAccountService>();

            builder.RegisterType<AccountProvider>().As<IAccountProvider>();

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

