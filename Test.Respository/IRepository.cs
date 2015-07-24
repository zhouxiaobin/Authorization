using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Respository
{
	public interface IRepository
	{
		/// <summary>
		/// 获取数据列表
		/// </summary>
		/// <param name="statementName">SQL语句名称</param>
		/// <param name="parameterObject">参数集</param>
		/// <returns>泛型数据列表</returns>
		IList<T> QueryForList<T>(string statementName, object parameterObject);
	}
}
