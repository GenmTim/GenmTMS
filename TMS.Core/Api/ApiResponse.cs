using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Api
{
	public class ApiResponse
	{

		/// <summary>
		/// 后台消息
		/// </summary>
		private string message;

		/// <summary>
		/// 返回状态
		/// </summary>
		private int statusCode;

		/// <summary>
		/// 返回结果
		/// </summary>
		private Object data;

		public ApiResponse(int statusCode, object data=null)
		{
			this.statusCode = statusCode;
			this.data = data;
		}

		public ApiResponse(int statusCode, string message = "")
		{
			this.statusCode = statusCode;
			this.message = message;
		}

		public string Message { get => message; set => message = value; }
		public int StatusCode { get => statusCode; set => statusCode = value; }
		public object Data { get => data; set => data = value; }
	}
}
