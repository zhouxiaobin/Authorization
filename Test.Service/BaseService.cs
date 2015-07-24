using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Respository;

namespace Test.Service
{
	public class BaseService : IBaseService
	{
		private readonly IRepository repository;

		public BaseService()
		{
		}

		/// <summary>
		/// 构造函数，用于依赖注入。
		/// </summary>
		/// <param name="repository"></param>
		public BaseService(IRepository repository)
		{
			this.repository = repository;
		}
		/// <summary>
		/// 获取数据列表
		/// </summary>
		/// <param name="statementName">SQL语句名称</param>
		/// <param name="parameterObject">参数集</param>
		/// <returns>泛型数据列表</returns>
		public IList<T> QueryForList<T>(string statementName, object parameterObject)
		{
			return repository.QueryForList<T>(statementName, parameterObject);
		}
	}
}
