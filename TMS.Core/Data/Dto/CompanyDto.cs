using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class CompanyDto
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        [JsonProperty("companyId", NullValueHandling = NullValueHandling.Ignore)]
        public int? CompanyId { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// 行业
        /// </summary>
        [JsonProperty("industry", NullValueHandling = NullValueHandling.Ignore)]
        public string? Industry { get; set; }

        /// <summary>
        /// 规模
        /// </summary>
        [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
        public string? Scale { get; set; }

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
        public string? contacts_email { get; set; }

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
