using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class ChatGroupDto
	{
		/// <summary>
		/// 群组ID
		/// </summary>
		[JsonProperty("group_id")]
		public int GroupId { get; set; }

		/// <summary>
		/// 管理员ID
		/// </summary>
		[JsonProperty("admin_id")]
		public int AdminId { get; set; }

		/// <summary>
		/// 创建者ID
		/// </summary>
		[JsonProperty("creator_id")]
		public int CreatorId { get; set; }

		/// <summary>
		/// 群组描述
		/// </summary>
		[JsonProperty("describe")]
		public string Describe { get; set; }

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
