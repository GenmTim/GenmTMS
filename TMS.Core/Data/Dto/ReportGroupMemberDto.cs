using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class ReportGroupMemberDto
    {
        /// <summary>
        /// 汇报组ID
        /// </summary>
        [JsonProperty("reportGroup_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReportGroupId { get; set; }

        /// <summary>
        /// 汇报人员ID
        /// </summary>
        [JsonProperty("reporter_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReporterId { get; set; }

        /// <summary>
        /// 提交的考评内容
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string? Content { get; set; }

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
