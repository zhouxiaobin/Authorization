using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Test.Respository;
using Test.Service;

namespace Test.Web.Ioc
{
	public class Boot
	{
		public static ContainerBuilder Initialise()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<Repository>().As<IRepository>().InstancePerDependency();
			builder.RegisterType<BaseService>().As<IBaseService>().InstancePerDependency();
			return builder;
		}
	}
}