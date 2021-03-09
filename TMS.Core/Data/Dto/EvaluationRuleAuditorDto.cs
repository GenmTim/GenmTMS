using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class EvaluationRuleAuditorDto
	{
		/// <summary>
		/// 考评组ID
		/// </summary>
		[JsonProperty("evaluationGroup_id")]
		public int EvaluationGroupId { get; set; }

		/// <summary>
		/// 审核人ID
		/// </summary>
		[JsonProperty("auditor_id")]
		public int AuditorId { get; set; }

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
