using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zero.Gdk;

namespace Zero.Game
{
	public abstract class UnityConnectionLogic : ConnectionLogic
	{
		public ZeroUnityHandle Handle => ZeroUnityHandle.Instance;

		public override Task DestroyAsync()
		{
			throw new NotImplementedException();
		}

		public override Task<bool> InitAsync(Dictionary<string, string> data)
		{
			throw new NotImplementedException();
		}
	}
}