using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class AttendanceClockDto
    {
        /// <summary>
        /// 打卡ID
        /// </summary>
        [JsonProperty("clock_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? ClockId { get; set; }

        /// <summary>
        /// 打卡用户ID
        /// </summary>
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserId { get; set; }

        /// <summary>
        /// 考勤组ID
        /// </summary>
        [JsonProperty("attendanceGroup_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? AttendanceGroupId { get; set; }

        /// <summary>
        /// 第几次上下班
        /// </summary>
        [JsonProperty("clock_num", NullValueHandling = NullValueHandling.Ignore)]
        public int? ClockNum { get; set; }

        /// <summary>
        /// 打卡类型
        /// </summary>
        [JsonProperty("clock_type", NullValueHandling = NullValueHandling.Ignore)]
        public int? ClockType { get; set; }

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
