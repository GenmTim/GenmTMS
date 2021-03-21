using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class BlDeptDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [JsonProperty("dept_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? DeptId { get; set; }

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
