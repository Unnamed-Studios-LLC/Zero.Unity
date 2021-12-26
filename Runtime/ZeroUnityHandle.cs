using UnityEngine;

namespace Zero.Game
{
	public class ZeroUnityHandle : MonoBehaviour
	{
		public static ZeroUnityHandle Instance;

		private void Awake()
		{
			Instance = this;
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}
	}
}