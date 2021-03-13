using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class CompanyInfoDto
	{
		/// <summary>
		/// 企业ID
		/// </summary>
		[JsonProperty("company_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? CompanyId { get; set; }

		/// <summary>
		/// 联系人姓名
		/// </summary>
		[JsonProperty("contacts_name", NullValueHandling = NullValueHandling.Ignore)]
		public string? ContactsName { get; set; }

		/// <summary>
		/// 联系人手机
		/// </summary>
		[JsonProperty("contacts_tel", NullValueHandling = NullValueHandling.Ignore)]
		public string? ContactsTel { get; set; }

		/// <summary>
		/// 联系人邮箱
		/// </summary>
		[JsonProperty("contacts_email", NullValueHandling = NullValueHandling.Ignore)]
		public string? ContactsEmail { get; set; }

		/// <summary>
		/// 座机
		/// </summary>
		[JsonProperty("plane", NullValueHandling = NullValueHandling.Ignore)]
		public string? Plane { get; set; }

		/// <summary>
		/// 国家或地区
		/// </summary>
		[JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
		public string? Country { get; set; }

		/// <summary>
		/// 企业地址
		/// </summary>
		[JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
		public string? Address { get; set; }

		/// <summary>
		/// 邮编
		/// </summary>
		[JsonProperty("postcode", NullValueHandling = NullValueHandling.Ignore)]
		public string? PostCode { get; set; }

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
