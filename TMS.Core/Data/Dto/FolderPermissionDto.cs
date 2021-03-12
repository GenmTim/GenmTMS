using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class FolderPermissionDto
	{
		/// <summary>
		/// 权限id
		/// </summary>
		[JsonProperty("permission_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? PermissionId { get; set; }

		/// <summary>
		/// 权限名
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string? Name { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[JsonProperty("describe", NullValueHandling = NullValueHandling.Ignore)]
		public string? Describe { get; set; }

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
