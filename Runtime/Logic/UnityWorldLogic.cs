using System.Collections.Generic;
using System.Threading.Tasks;
using Zero.Gdk;

namespace Zero.Game
{
	public abstract class UnityWorldLogic : WorldLogic
	{
		public ZeroUnityHandle Handle => ZeroUnityHandle.Instance;

		public override Task DestroyAsync()
		{
			throw new System.NotImplementedException();
		}

		public override Task<bool> InitAsync(Dictionary<string, string> data)
		{
			throw new System.NotImplementedException();
		}
	}
}