using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class ReportGroupMemberDto
	{
		/// <summary>
		/// 汇报组ID
		/// </summary>
		[JsonProperty("reportGroup_id")]
		public int ReportGroupId { get; set; }

		/// <summary>
		/// 汇报人员ID
		/// </summary>
		[JsonProperty("reporter_id")]
		public int ReporterId { get; set; }

		/// <summary>
		/// 提交的考评内容
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
