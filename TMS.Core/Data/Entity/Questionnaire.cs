using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Entity
{
	public class Questionnaire
	{
		public string Title { get; set; }
		/// <summary>
		/// 问卷名
		/// </summary>
		public string EvaluationName { get; set; }

		public string Date { get; set; }

		public string Time { get; set; }
		/// <summary>
		/// 问卷内容标题列表
		/// </summary>
		public List<string> ContentList { get; set; }
	}
}
