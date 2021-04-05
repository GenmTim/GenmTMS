using Newtonsoft.Json;
using Prism.Events;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;
using TMS.Core.Event;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;
using WebSocket4Net;

namespace TMS.Core.Api
{
	public class WebSocketService
	{
		private readonly IEventAggregator eventAggregator;
		private readonly WebSocket conn;


		public WebSocketService(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			conn = new WebSocket("ws://47.101.157.194:8081/webSocket/" + SessionService.User.UserId);
			conn.Opened += new EventHandler(OnOpened);
            conn.MessageReceived += new EventHandler<MessageReceivedEventArgs>(OnReceived);
            conn.Error += new EventHandler<ErrorEventArgs>(OnError);
			conn.Closed += new EventHandler(OnClosed);
			conn.Open();
		}

        public void SendNotification(NotificationData notificationData)
        {
            string data = JsonConvert.SerializeObject(notificationData);
			LoggerService.Info("WebSocketService: " + data);
			conn.Send(data);
        }

		/// <summary>
		/// WebScoket 建立连接后
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void OnOpened(object sender, EventArgs e)
		{
			eventAggregator.GetEvent<WebSocketSendEvent>().Subscribe(SendNotification);
		}

		/// <summary>
		/// WebSocket 接收数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReceived(object sender, MessageReceivedEventArgs e)
		{
			var data = e.Message;
			if (string.IsNullOrEmpty(data)) return;

			try
			{
				NotificationData notificationData = JsonConvert.DeserializeObject<NotificationData>(data);
				if (notificationData.Type == 0)
                {
					if (notificationData.SubType == 0)
                    {
						eventAggregator.GetEvent<WebSocketRecvEvent>().Publish(notificationData);
					}
					else
                    {

                    }
                }
			}
			catch (Exception) {}
		}

		/// <summary>
		/// WebSocket 产生错误信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnError(object sender, ErrorEventArgs e)
		{
			// pass
			LoggerService.Error("WebSocketService: " + e.ToString());
		}

		/// <summary>
		/// WebSocket 关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClosed(object sender, EventArgs e)
		{
			Task.Factory.StartNew(async() => 
			{
				await Task.Delay(3);
				conn.Open();
			});
			// pass
			LoggerService.Warn("WebSocketService: " + "Close");
		}
	}
}
