using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Entity
{
	public class Recruit
	{
		public string JobtitleName { get; set; }

		public int WorkExperience { get; set; }

		public string Date { get; set; }

		public string Time { get; set; }
		/// <summary>
		/// 职位描述
		/// </summary>
		public string JobDescribe { get; set; }
	}
}
