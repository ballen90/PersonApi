using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebApplication2.BusinessLayer;
using WebApplication2.BusinessLayer.Interfaces;
using WebApplication2.DataLayer;
using WebApplication2.DataLayerInterfaces;

namespace WebApplication2.App_Start
{
    public class AutoFacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PersonBusinessLayer>().As<IPersonBusinessLayer>();
            builder.RegisterType<PersonDataLayer>().As<IPersonDataLayer>();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}