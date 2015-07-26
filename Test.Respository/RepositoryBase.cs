using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;

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

		protected static object QueryForObject<T>(ISqlMapper sqlMap, string statementName, object parameterObject)
		{
			T obj = sqlMap.QueryForObject<T>(statementName, parameterObject);

			return obj;
		}

		/// <summary>
		/// 获取执行的SQL语句
		/// </summary>
		/// <param name="statementName">SQL语句名称/param>
		/// <param name="paramObject">参数</param>
		/// <returns>返回需要监控的SQL语句</returns>
		public static string GetRuntimeSql(ISqlMapper sqlMapper, string statementName, object paramObject)
		{
			string result = string.Empty;
			try
			{
				IMappedStatement statement = sqlMapper.GetMappedStatement(statementName);
				if (!sqlMapper.IsSessionStarted)
				{
					sqlMapper.OpenConnection();
				}
				RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, sqlMapper.LocalSession);
				result = scope.PreparedStatement.PreparedSql;
			}
			catch (Exception ex)
			{
				result = "获取SQL语句出现异常:" + ex.Message;
			}
			return result;
		}

	}
}
