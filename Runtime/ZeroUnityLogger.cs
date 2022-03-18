using System;
using System.Collections.Concurrent;
using UnityEngine;
using Zero.Game.Shared;

namespace Zero.Unity
{
	public class ZeroUnityLogger : ILoggingProvider
	{
		private class Logged
		{
            public Logged(LogLevel level, string message, string exception)
            {
                Level = level;
                Message = message;
				Exception = exception;
            }

			public LogLevel Level { get; }

			public string Message { get; }

			public string Exception { get; }
		}

		private readonly ConcurrentQueue<Logged> _logQueue = new ConcurrentQueue<Logged>();

		public void Update()
		{
			while (_logQueue.TryDequeue(out var logged))
			{
				InternalLog(logged);
			}
		}

		private void InternalLog(Logged logged)
		{
			var logFunc = (logged.Level == LogLevel.Error || logged.Level == LogLevel.Critical) ? (Action<string>)Debug.LogError : Debug.Log;
			if (logged.Exception != null)
			{
				logFunc($"[{logged.Level.ToString().ToUpper()}] {logged.Message}");
			}
			else
			{
				logFunc($"[{logged.Level.ToString().ToUpper()}] {logged.Message}\n{logged.Exception}");
			}
		}

        public void Log(LogLevel logLevel, string message, Exception e)
        {
			_logQueue.Enqueue(new Logged(logLevel, message, e?.ToString()));
        }

        public void Log(LogLevel logLevel, string format, object[] args, Exception e)
        {
			Log(logLevel, string.Format(format, args), e);
        }
    }
}