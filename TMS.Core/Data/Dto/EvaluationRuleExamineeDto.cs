using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class EvaluationRuleExamineeDto
	{
		/// <summary>
		/// 考评组ID
		/// </summary>
		[JsonProperty("evaluationGroup_id")]
		public int EvaluationGroupId { get; set; }

		/// <summary>
		/// 考评对象ID
		/// </summary>
		[JsonProperty("examinee_id")]
		public int ExamineeId { get; set; }

		/// <summary>
		/// 提交考评内容
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty("create_at")]
		public DateTime CreateAt { get; set; }

		/// <summary>
		/// 最近更新时间
		/// </summary>
		[JsonProperty("update_at")]
		public DateTime UpdateAt { get; set; }
	}
}
