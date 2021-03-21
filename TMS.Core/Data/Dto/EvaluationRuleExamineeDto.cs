using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class EvaluationRuleExamineeDto
    {
        /// <summary>
        /// 考评组ID
        /// </summary>
        [JsonProperty("evaluationGroup_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? EvaluationGroupId { get; set; }

        /// <summary>
        /// 考评对象ID
        /// </summary>
        [JsonProperty("examinee_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? ExamineeId { get; set; }

        /// <summary>
        /// 提交考评内容
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
