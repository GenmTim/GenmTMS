using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class FolderDto
	{
		/// <summary>
		/// 文件夹id
		/// </summary>
		[JsonProperty("folder_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? FolderId { get; set; }

		/// <summary>
		/// 文件夹名
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string? Name { get; set; }

		/// <summary>
		/// 所有者id
		/// </summary>
		[JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? UserId { get; set; }

		/// <summary>
		/// 上级目录id
		/// </summary>
		[JsonProperty("parent_folder", NullValueHandling = NullValueHandling.Ignore)]
		public int? ParentFolder { get; set; }

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
