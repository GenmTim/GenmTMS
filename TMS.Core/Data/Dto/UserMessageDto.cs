using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class UserMessageDto
	{
		/// <summary>
		/// 消息ID
		/// </summary>
		[JsonProperty("message_id")]
		public int MessageId { get; set; }

		/// <summary>
		/// 接收者ID
		/// </summary>
		[JsonProperty("receiver_id")]
		public int ReceiverId { get; set; }

		/// <summary>
		/// 发送者ID
		/// </summary>
		[JsonProperty("sender_id")]
		public int SenderId { get; set; }

		/// <summary>
		/// 消息内容
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }
		
		/// <summary>
		/// 消息类型
		/// </summary>
		[JsonProperty("type")]
		public int Type { get; set; }

		/// <summary>
		/// 消息状态
		/// </summary>
		[JsonProperty("status")]
		public MessageStatus Status { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty("create_at")]
		public DateTime CreateAt { get; set; }

		/// <summary>
		/// 最近更新时间
		/// </summary>
		[JsonProperty("update_at")]
		public DateTime UpdateAt { get; set; }

		//debug 自动转换的枚举类型
		public enum MessageStatus
		{
			Unread=0,
			Read=1
		}
	}
}
