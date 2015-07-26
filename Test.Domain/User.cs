using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string UserPwd { get; set; }
		public int RoleId { get; set; }
		public DateTime CreateTime { get; set; }

	}
}
