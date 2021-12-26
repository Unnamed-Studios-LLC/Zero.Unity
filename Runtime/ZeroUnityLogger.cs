using System;
using System.Collections.Concurrent;
using UnityEngine;
using Zero.Gdk;

namespace Zero.Game
{
	public class ZeroUnityLogger : Zero.Gdk.ILogger
	{
		private class Logged
		{
			public LogLevel Level;

			public string Message;
		}

		private readonly ConcurrentQueue<Logged> _logQueue = new ConcurrentQueue<Logged>();

		public void Log(LogLevel level, string message)
		{
			_logQueue.Enqueue(new Logged
			{
				Level = level,
				Message = message
			});
		}

		public void LogCritical(string message)
		{
			Log(LogLevel.Critical, message);
		}

		public void LogCritical(Exception exception, string message)
		{
			Log(LogLevel.Critical, $"{message}\n{exception}");
		}

		public void LogDebug(string message)
		{
			Log(LogLevel.Debug, message);
		}

		public void LogError(string message)
		{
			Log(LogLevel.Error, message);
		}

		public void LogError(Exception exception, string message)
		{
			Log(LogLevel.Error, $"{message}\n{exception}");
		}

		public void LogInformation(string message)
		{
			Log(LogLevel.Information, message);
		}

		public void LogTrace(string message)
		{
			Log(LogLevel.Trace, message);
		}

		public void LogWarning(string message)
		{
			Log(LogLevel.Warning, message);
		}

		public void Update()
		{
			while (_logQueue.TryDequeue(out var logged))
			{
				InternalLog(logged.Level, logged.Message);
			}
		}

		private void InternalLog(LogLevel level, string message)
		{
			var logFunc = (level == LogLevel.Error || level == LogLevel.Critical) ? (Action<string>)Debug.LogError : Debug.Log;
			logFunc($"[{level.ToString().ToUpper()}] {message}");
		}
	}
}