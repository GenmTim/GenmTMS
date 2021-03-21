using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class AttendanceMemberDto
    {
        /// <summary>
        /// 考勤组ID
        /// </summary>
        [JsonProperty("attendanceGroup_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? AttendanceGroupId { get; set; }

        /// <summary>
        /// 考勤人员ID
        /// </summary>
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserId { get; set; }

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
