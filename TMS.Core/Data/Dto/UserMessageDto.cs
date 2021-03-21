using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class UserMessageDto
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? MessageId { get; set; }

        /// <summary>
        /// 接收者ID
        /// </summary>
        [JsonProperty("receiver_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReceiverId { get; set; }

        /// <summary>
        /// 发送者ID
        /// </summary>
        [JsonProperty("sender_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? SenderId { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string? Content { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int? Type { get; set; }

        /// <summary>
        /// 消息状态
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public MessageStatus Status { get; set; }

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

        //debug 自动转换的枚举类型
        public enum MessageStatus
        {
            Unread = 0,
            Read = 1
        }
    }
}
