using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;
using WebSocketSharp;

namespace TMS.Core.Api
{
	public static class WebSocketService
	{
		private static WebSocket conn = new WebSocket("ws://121.40.165.18:8800");

		private static bool isConnect = false;

		static WebSocketService()
		{
			conn.OnOpen += Conn_OnOpen;
			conn.OnMessage += Conn_OnMessage;
			conn.OnError += Conn_OnError;
			conn.OnClose += Conn_OnClose;
			conn.Connect();
		}

		public static void Conn_SendMessage()
		{

		}

		public static void SendMessage(NotificationData data)
		{
			if (isConnect)
			{
				//已连接
			}
			else
			{
				//未连接
			}
		}

		private static void Conn_OnOpen(object sender, EventArgs e)
		{
			isConnect = true;
		}

		private static void Conn_OnMessage(object sender, MessageEventArgs e)
		{

		}

		private static void Conn_OnError(object sender, ErrorEventArgs e)
		{

		}

		private static void Conn_OnClose(object sender, CloseEventArgs e)
		{

		}

	}
}
