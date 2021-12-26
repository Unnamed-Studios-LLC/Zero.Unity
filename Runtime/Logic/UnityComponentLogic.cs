using UnityEngine;
using Zero.Gdk;

namespace Zero.Game
{
	public abstract class UnityComponentLogic<T> : ComponentLogic<T>
		where T : class, ITyped, new()
	{
		public GameObject GameObject
		{
			get
			{
				var entityLogic = Component.Entity.Logic as UnityEntityLogic;
				if (entityLogic == null)
				{
					return null;
				}
				return entityLogic.GameObject;
			}
		}
		public ZeroUnityHandle Handle => ZeroUnityHandle.Instance;
	}
}