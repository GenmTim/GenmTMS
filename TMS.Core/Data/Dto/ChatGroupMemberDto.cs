using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class ChatGroupMemberDto
	{
		/// <summary>
		/// 群组ID
		/// </summary>
		[JsonProperty("group_id")]
		public int GroupId { get; set; }

		/// <summary>
		/// 成员ID
		/// </summary>
		[JsonProperty("user_id")]
		public int UserId { get; set; }

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
