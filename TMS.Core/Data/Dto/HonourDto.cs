using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class HonourDto
    {
        /// <summary>
        /// 荣耀ID
        /// </summary>
        [JsonProperty("honour_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? HonourId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserId { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        [JsonProperty("jobtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string? Jobtitle { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [JsonProperty("dept_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? DeptId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [JsonProperty("dept_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? DeptName { get; set; }

        /// <summary>
        /// 荣耀类型
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        /// <summary>
        /// 荣耀获取时间
        /// </summary>
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Time { get; set; }

        /// <summary>
        /// 主要事迹
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark", NullValueHandling = NullValueHandling.Ignore)]
        public string? Remark { get; set; }

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
