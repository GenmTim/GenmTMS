using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class UserDto
	{
		/// <summary>
		/// 用户id
		/// </summary>
		[JsonProperty("user_id")]
		public int UserId { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[JsonProperty("password")]
		public string Password { get; set; }

		/// <summary>
		/// 邮箱
		/// </summary>
		[JsonProperty("email")]
		public string Email { get; set; }

		/// <summary>
		/// 手机号
		/// </summary>
		[JsonProperty("tel")]
		public string Tel { get; set; }

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
