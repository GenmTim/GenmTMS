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
		[JsonProperty("company_id")]
		public int CompanyId { get; set; }

		/// <summary>
		/// 联系人姓名
		/// </summary>
		[JsonProperty("contacts_name")]
		public string ContactsName { get; set; }

		/// <summary>
		/// 联系人手机
		/// </summary>
		[JsonProperty("contacts_tel")]
		public string ContactsTel { get; set; }

		/// <summary>
		/// 联系人邮箱
		/// </summary>
		[JsonProperty("contacts_email")]
		public string ContactsEmail { get; set; }

		/// <summary>
		/// 座机
		/// </summary>
		[JsonProperty("plane")]
		public string Plane { get; set; }

		/// <summary>
		/// 国家或地区
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

		/// <summary>
		/// 企业地址
		/// </summary>
		[JsonProperty("address")]
		public string Address { get; set; }

		/// <summary>
		/// 邮编
		/// </summary>
		[JsonProperty("postcode")]
		public string PostCode { get; set; }

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
