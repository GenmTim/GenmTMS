using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class UserInfoDto
	{
		/// <summary>
		/// 用户id
		/// </summary>
		[JsonProperty("user_id")]
		public int UserId { get; set; }

		/// <summary>
		/// 头像
		/// </summary>
		[JsonProperty("avatar")]
		public string Avatar { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[JsonProperty("gender")]
		public int Gender { get; set; }

		/// <summary>
		/// 城市
		/// </summary>
		[JsonProperty("city")]
		public string City { get; set; }

		/// <summary>
		/// 省份
		/// </summary>
		[JsonProperty("province")]
		public string Province { get; set; }

		/// <summary>
		/// 国家
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

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
