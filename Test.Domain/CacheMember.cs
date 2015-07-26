using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
	/// <summary>
	/// 用户详细角色权限信息
	/// </summary>
	public class CacheMember
	{
		public User User { get; set; }
		public IList<Role> Roles { get; set; }
		public IList<Menu> Menus { get; set; }
	}
}
