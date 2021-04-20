using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Entity
{
	public class Talent
	{
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 职位
		/// </summary>
		public string Jobtitle { get; set; }
		/// <summary>
		/// 工龄
		/// </summary>
		public int JobAge { get; set; }

		public string City { get; set; }
		/// <summary>
		/// 关注人数
		/// </summary>
		public int FollowNumber { get; set; }
	}
}
