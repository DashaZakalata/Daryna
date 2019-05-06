using ApplicationServices;
using DAL;
using DomainServices.Repositories;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_application.Utils
{
    public class DependencyRegistrations : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IShopContext>().To<ShopContext>();
            Bind<IGoodRepository>().To<GoodRepository>();
            Bind<IGoodBO>().To<GoodBO>();
        }
    }
}