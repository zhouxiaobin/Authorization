using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace Test.Respository
{
	public class MyIbatisNet
	{
		public static ISqlMapper SqlMap;
		private static readonly object syncObj = new object();
		static MyIbatisNet()
		{
			if (SqlMap == null)
			{
				lock (syncObj)
				{
					if (SqlMap == null)
					{
						Assembly assembly = Assembly.Load("Test.Respository");
						Stream stream = assembly.GetManifestResourceStream("Test.Respository.sqlmap.config");
						DomSqlMapBuilder builder = new DomSqlMapBuilder();
						SqlMap = builder.Configure(stream);
					}
				}
			}
		}
	}
}
