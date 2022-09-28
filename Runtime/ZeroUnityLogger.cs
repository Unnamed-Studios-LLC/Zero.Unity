using System;
using System.Collections.Concurrent;
using System.Text;
using Zero.Game.Shared;

namespace Zero.Unity
{
	public class ZeroUnityLogger : ILoggingProvider
	{
		private struct LogEntry
		{
            public LogEntry(LogLevel level, string message, string exception)
            {
                Level = level;
                Message = message;
				Exception = exception;
            }

			public LogLevel Level { get; }

			public string Message { get; }

			public string Exception { get; }
		}

		private readonly ConcurrentQueue<LogEntry> _logQueue = new();
		private readonly StringBuilder _builder = new();

        public void Log(LogLevel logLevel, string message, Exception e)
        {
			_logQueue.Enqueue(new LogEntry(logLevel, message, e?.ToString()));
        }

        public void Log(LogLevel logLevel, string format, object[] args, Exception e)
        {
			Log(logLevel, string.Format(format, args), e);
		}

		public void Update()
		{
			while (_logQueue.TryDequeue(out var logged))
			{
				InternalLog(ref logged);
			}
		}

		private void InternalLog(ref LogEntry logged)
		{
			var logFunc = (logged.Level == LogLevel.Error || logged.Level == LogLevel.Critical) ? (Action<string>)UnityEngine.Debug.LogError : UnityEngine.Debug.Log;
			_builder.Append(GetLogLevelString(logged.Level));
			_builder.Append(": ");
			if (logged.Exception == null)
			{
				_builder.Append(logged.Message);
			}
			else
			{
				_builder.Append(logged.Message);
				_builder.Append("\n");
				_builder.Append(logged.Exception);
			}
			logFunc(_builder.ToString());
			_builder.Clear();
		}

		private static string GetLogLevelString(LogLevel logLevel)
		{
			return logLevel switch
			{
				LogLevel.Trace => "trce",
				LogLevel.Debug => "dbug",
				LogLevel.Information => "info",
				LogLevel.Warning => "warn",
				LogLevel.Error => "fail",
				LogLevel.Critical => "crit",
				_ => "    "
			};
		}
	}
}