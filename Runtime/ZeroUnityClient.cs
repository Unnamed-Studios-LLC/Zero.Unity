using System;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using Zero.Gdk;
using Zero.Node.Client;

namespace Zero.Game
{
	public class ZeroUnityClient
	{
		private readonly ZeroUnityLogger _logger = new ZeroUnityLogger();
		private readonly ClientNode _node;
		private readonly ushort _type;

		private Task<bool> _startTask;

		public ZeroUnityClient(ISetup setup, ushort type)
		{
			_node = new ClientNode(setup, _logger);
			_type = type;
		}

		public void Connect(IPAddress ipAddress, string key)
		{
			Debug.Log(key);
			_startTask = _node.StartAsync(ipAddress, _type, key);
		}

		public void Disconnect()
		{
			_node.Disconnect();
		}

		public void Update()
		{
			_logger.Update();
			UpdateStarting();
			UpdateNode();
		}

		private void UpdateNode()
		{
			_node.Update();
		}

		private void UpdateStarting()
		{
			if (_startTask == null ||
				!_startTask.IsCompleted)
			{
				return;
			}

			try
			{
				var result = _startTask.Result;
				Debug.Log("Connect result: " + result);
			}
			catch (Exception e)
			{
				Debug.LogError(e);
			}

			_startTask = null;
		}
	}
}
