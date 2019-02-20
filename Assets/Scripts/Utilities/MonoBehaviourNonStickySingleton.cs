using UnityEngine;

namespace Utilities.Singleton{
	//Sticking singleton template
	public abstract class MonoBehaviourNonStickySingleton<T> : MonoBehaviour where T : MonoBehaviourNonStickySingleton<T> {
		//Instace
		public static T Instance { get; private set; }

		//Manage the singleton lifecycle
		protected virtual void Awake() {
			if (!Instance) {
				Instance = (T)this;
			}
		}
	}
}