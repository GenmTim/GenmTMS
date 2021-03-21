using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class EvaluationGroupDto
    {
        /// <summary>
        /// 考评组ID
        /// </summary>
        [JsonProperty("evaluationGroup_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? EvaluationGroupId { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string? Subject { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 考评内容模板
        /// </summary>
        [JsonProperty("template", NullValueHandling = NullValueHandling.Ignore)]
        public string? Template { get; set; }

        /// <summary>
        /// 考评负责人
        /// </summary>
        [JsonProperty("examiner_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? ExaminerId { get; set; }

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
