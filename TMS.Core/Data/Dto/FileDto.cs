using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class FileDto
	{
		/// <summary>
		/// 文件id
		/// </summary>
		[JsonProperty("file_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? FileId { get; set; }

		/// <summary>
		/// 文件名
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string? Name { get; set; }

		/// <summary>
		/// 所属目录
		/// </summary>
		[JsonProperty("owner_folder_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? OwnerFolderId { get; set; }

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
