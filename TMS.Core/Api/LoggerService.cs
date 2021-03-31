using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Api
{
	public class LoggerService
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		static LoggerService()
		{
			Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
			LogManager.Configuration = new XmlLoggingConfiguration(
				System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\NLog.config");
		}

		public static void Debug(string message)
		{
			logger.Debug(message);
		}

		public static void Debug(object value)
		{
			logger.Debug(value);
		}

		public static void Error(object value)
		{
			logger.Error(value);
		}

		public static void Error(string message)
		{
			logger.Error(message);
		}

		public static void Info(object value)
		{
			logger.Info(value);
		}

		public static void Info(string message)
		{
			logger.Info(message);
		}

		public static void Trace(object value)
		{
			logger.Trace(value);
		}

		public static void Trace(string message)
		{
			logger.Trace(message);
		}

		public static void Warn(object value)
		{
			logger.Warn(value);
		}

		public static void Warn(string message)
		{
			logger.Warn(message);
		}
	}
}
