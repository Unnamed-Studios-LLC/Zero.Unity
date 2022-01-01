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

		public ZeroUnityClient(ISetup setup, ushort type)
		{
			_node = new ClientNode(setup, _logger);
			_type = type;
		}

		public Task async Connect(IPAddress ipAddress, string key)
		{
			try
			{
				var result = await _node.StartAsync(ipAddress, _type, key);
				_logger.LogInformation($"Connect result: {result}");
			}
			catch (Exception e)
			{
				_logger.LogError(e, "An error occurred during Connect");
			}
		}

		public void Disconnect()
		{
			_node.Disconnect();
		}

		public void Update()
		{
			_logger.Update();
			UpdateNode();
		}

		private void UpdateNode()
		{
			_node.Update();
		}
	}
}
