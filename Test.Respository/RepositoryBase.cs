using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Respository
{
	public class RepositoryBase
	{/// <summary>
		/// 获取数据列表
		/// </summary>
		/// <param name="sqlMap">ISqlMapper对象</param>
		/// <param name="statementName">SQL语句名称</param>
		/// <param name="parameterObject">参数集</param>
		/// <returns>泛型数据列表</returns>
		protected static IList<T> QueryForList<T>(ISqlMapper sqlMap, string statementName, object parameterObject)
		{
			IList<T> list = sqlMap.QueryForList<T>(statementName, parameterObject);
			if (list == null)
			{
				list = new List<T>();
			}
			return list;
		}

	}
}
