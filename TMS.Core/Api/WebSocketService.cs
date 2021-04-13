using Newtonsoft.Json;
using Prism.Events;
using SuperSocket.ClientEngine;
using System;
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
        private int delayTime = 2000;


        public WebSocketService(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            conn = new WebSocket("ws://47.101.157.194:8081/webSocket/" + SessionService.Instance.User.UserId);
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
            eventAggregator.GetEvent<ToastShowEvent>().Publish("已与服务器建立连接");
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

                if (notificationData.SubType == 0)
                {
                    eventAggregator.GetEvent<WebSocketRecvEvent>().Publish(notificationData);
                }
                else
                {

                }
            }
            catch (Exception) { }
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
            //if (delayTime > 200000)
            //         {

            //         }
        }

        /// <summary>
        /// WebSocket 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClosed(object sender, EventArgs e)
        {
            eventAggregator.GetEvent<ToastShowEvent>().Publish("服务器连接已断开");
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(delayTime);
                conn.Open();
            });
            // pass
            LoggerService.Warn("WebSocketService: " + "Close");
        }
    }
}
