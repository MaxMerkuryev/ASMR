using UnityEngine;

namespace CameraShake
{
	public class CameraShakeTrigger : MonoBehaviour
	{
		public void Invoke(float magnitude) => CameraShaker.ShakeEvent.Invoke(magnitude);
	}
}