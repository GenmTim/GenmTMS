using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class ReportGroupAuditorDto
	{
		/// <summary>
		/// 汇报组ID
		/// </summary>
		[JsonProperty("reportGroup_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? ReportGroupId { get; set; }

		/// <summary>
		/// 审核人ID
		/// </summary>
		[JsonProperty("auditor_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? AuditorId { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty("create_at", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? CreateAt { get; set; }

		/// <summary>
		/// 最近更新时间
		/// </summary>
		[JsonProperty("update_at", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? UpdateAt { get; set; }
	}
}
