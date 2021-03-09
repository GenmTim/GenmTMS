using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class DeptDto
	{
		/// <summary>
		/// 部门ID
		/// </summary>
		[JsonProperty("dept_id")]
		public int DeptId { get; set; }

		/// <summary>
		/// 企业ID
		/// </summary>
		[JsonProperty("company_id")]
		public int CompanyId { get; set; }

		/// <summary>
		/// 部门名称
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 上级部门
		/// </summary>
		[JsonProperty("parent_dept")]
		public int ParentDept { get; set; }

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
