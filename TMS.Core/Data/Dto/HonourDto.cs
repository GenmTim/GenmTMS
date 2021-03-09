using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class HonourDto
	{
		/// <summary>
		/// 荣耀ID
		/// </summary>
		[JsonProperty("honour_id")]
		public int HonourId { get; set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		[JsonProperty("user_id")]
		public int UserId { get; set; }

		/// <summary>
		/// 职称
		/// </summary>
		[JsonProperty("jobtitle")]
		public string Jobtitle { get; set; }

		/// <summary>
		/// 部门ID
		/// </summary>
		[JsonProperty("dept_id")]
		public int DeptId { get; set; }

		/// <summary>
		/// 部门名称
		/// </summary>
		[JsonProperty("dept_name")]
		public string DeptName { get; set; }

		/// <summary>
		/// 荣耀类型
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// 荣耀获取时间
		/// </summary>
		[JsonProperty("time")]
		public DateTime Time { get; set; }

		/// <summary>
		/// 主要事迹
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty("remark")]
		public string Remark { get; set; }

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
