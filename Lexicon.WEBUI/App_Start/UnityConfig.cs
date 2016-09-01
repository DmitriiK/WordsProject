using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Lexicon.Core;
using Lexicon.Data.EntityFramework;
using Lexicon.WebUI.Identity;
using Microsoft.AspNet.Identity;
using System;

namespace Lexicon.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("Lingva"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}