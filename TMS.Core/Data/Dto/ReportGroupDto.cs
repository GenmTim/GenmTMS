using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class ReportGroupDto
    {
        /// <summary>
        /// 汇报组ID
        /// </summary>
        [JsonProperty("reportGroup_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReportGroupId { get; set; }

        /// <summary>
        /// 汇报主题
        /// </summary>
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string? Subject { get; set; }

        /// <summary>
        /// 汇报负责人ID
        /// </summary>
        [JsonProperty("admin_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? AdminId { get; set; }

        /// <summary>
        /// 汇报时间规则
        /// </summary>
        [JsonProperty("time_rule", NullValueHandling = NullValueHandling.Ignore)]
        public string? TimeRule { get; set; }

        /// <summary>
        /// 考评内容模板
        /// </summary>
        [JsonProperty("template", NullValueHandling = NullValueHandling.Ignore)]
        public string? Template { get; set; }

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
