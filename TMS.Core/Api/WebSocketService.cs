using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;
using WebSocket4Net;

namespace TMS.Core.Api
{
	public class WebSocketService
	{
		private static WebSocketService instance;
		public static WebSocketService Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new WebSocketService();
				}
				return instance;
			}
		}

		public static WebSocketService GetInstance()
		{
			if (instance == null)
			{
				instance = new WebSocketService();
			}
			return instance;
		}

		public static WebSocketService GetConn()
		{
			if (instance == null)
			{
				instance = new WebSocketService();
			}
			return instance;
		}

		private WebSocketService()
		{
			conn = new WebSocket("ws://123.207.136.134:9010/ajaxchattest");
			conn.Opened += new EventHandler(OnOpened);
			conn.MessageReceived += new EventHandler<MessageReceivedEventArgs>(OnReceived);
			conn.Error += new EventHandler<ErrorEventArgs>(OnError);
			conn.Closed += new EventHandler(OnClosed);
			conn.Open();
		}

		private WebSocket conn = null;

		private bool isConnect = false;

		private Queue<NotificationData> dataQueue = new Queue<NotificationData>();

		private Queue<string> strQueue = new Queue<string>();

		public void SendMessage()
		{
			if (isConnect)
			{

			}
		}

		public void Send(string str)
		{
			if (isConnect)
			{
				conn.Send(str);
			}
			else
			{
				strQueue.Enqueue(str);
			}
		}

		public void SendMessage(NotificationData data)
		{
			if (isConnect)
			{
				//已连接
				//data处理
				string v = data.ToString();
				conn.Send(v);
			}
			else
			{
				//未连接
				dataQueue.Enqueue(data);
			}
		}

		public void ConnClose()
		{
			conn.Close();
		}

		private void OnOpened(object sender, EventArgs e)
		{
			Console.WriteLine("WebSocket连接成功");
			isConnect = true;
			try
			{
				NotificationData data = dataQueue.Dequeue();
				while (null != data)
				{
					//data处理
					conn.Send(data.ToString());

					//
					data = dataQueue.Dequeue();

				}

				string str = strQueue.Dequeue();
				while (!string.IsNullOrEmpty(str))
				{
					//data处理
					conn.Send(str);

					str = strQueue.Dequeue();

				}
			}
			catch (Exception)
			{
				Console.WriteLine("Queue没有内容");
			}

		}

		private void OnReceived(object sender, MessageReceivedEventArgs e)
		{
			Console.WriteLine(e.Message);

		}

		private void OnError(object sender, ErrorEventArgs e)
		{
			Console.WriteLine(e.Exception);
		}

		private void OnClosed(object sender, EventArgs e)
		{
			Console.WriteLine("OnClose:");
		}
	}
}
