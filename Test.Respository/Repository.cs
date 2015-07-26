using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataMapper;

namespace Test.Respository
{
	public class Repository : RepositoryBase, IRepository
	{
		/// <summary>
		/// 获取数据列表
		/// </summary>
		/// <param name="statementName">SQL语句名称</param>
		/// <param name="parameterObject">参数集</param>
		/// <returns>泛型数据列表</returns>
		public IList<T> QueryForList<T>(string statementName, object parameterObject)
		{
			ISqlMapper sqlMap = MyIbatisNet.SqlMap;
			return RepositoryBase.QueryForList<T>(sqlMap, statementName, parameterObject);
		}

		public object QueryForObject<T>(string statementName, object parameterObject)
		{
			ISqlMapper sqlMap = MyIbatisNet.SqlMap;
			return RepositoryBase.QueryForObject<T>(sqlMap, statementName, parameterObject);
		}

		public  string GetRuntimeSql(string statementName, object paramObject)
		{
			ISqlMapper sqlMap = MyIbatisNet.SqlMap;
			return RepositoryBase.GetRuntimeSql(sqlMap, statementName, paramObject);
		}
	}
}
