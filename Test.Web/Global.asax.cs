using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Test.Web.Ioc;

namespace Test.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			//Ioc注入配置项
			var builder = Boot.Initialise();

			////注册所有的MVC Controllers受控制
			builder.RegisterControllers(Assembly.GetExecutingAssembly());

			//注册Filter  目前测试只能注册到Filter的属性，无法通过构造函数实现注入，与Filter的生命周期有关
			builder.RegisterFilterProvider();

			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
