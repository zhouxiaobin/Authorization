﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
	public class Menu
	{
		public int Id { get; set; }
		public string ParentId { get; set; }
		public string MenuName { get; set; }
		public string Url { get; set; }
		public string Remark { get; set; }
	}
}
