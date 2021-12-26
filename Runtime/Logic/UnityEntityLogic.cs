using UnityEngine;
using Zero.Gdk;

namespace Zero.Game
{
	public abstract class UnityEntityLogic : EntityLogic
	{
		public GameObject GameObject { get; set; }
		public ZeroUnityHandle Handle => ZeroUnityHandle.Instance;
	}
}