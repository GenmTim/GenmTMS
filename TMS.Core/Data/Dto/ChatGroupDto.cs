using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class ChatGroupDto
    {
        /// <summary>
        /// 群组ID
        /// </summary>
        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? GroupId { get; set; }

        /// <summary>
        /// 管理员ID
        /// </summary>
        [JsonProperty("admin_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? AdminId { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [JsonProperty("creator_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatorId { get; set; }

        /// <summary>
        /// 群组描述
        /// </summary>
        [JsonProperty("describe", NullValueHandling = NullValueHandling.Ignore)]
        public string? Describe { get; set; }

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
