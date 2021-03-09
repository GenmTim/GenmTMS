using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class EvaluationGroupDto
	{
		/// <summary>
		/// 考评组ID
		/// </summary>
		[JsonProperty("evaluationGroup_id")]
		public int EvaluationGroupId { get; set; }

		/// <summary>
		/// 主题
		/// </summary>
		[JsonProperty("subject")]
		public string Subject { get; set; }

		/// <summary>
		/// 开始时间
		/// </summary>
		[JsonProperty("start_time")]
		public DateTime StartTime { get; set; }

		/// <summary>
		/// 结束时间
		/// </summary>
		[JsonProperty("end_time")]
		public DateTime EndTime { get; set; }

		/// <summary>
		/// 考评内容模板
		/// </summary>
		[JsonProperty("template")]
		public string Template { get; set; }

		/// <summary>
		/// 考评负责人
		/// </summary>
		[JsonProperty("examiner_id")]
		public int ExaminerId { get; set; }

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
