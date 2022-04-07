using System;
using DG.Tweening;
using UnityEngine;

namespace CameraShake
{
	public class CameraShaker : MonoBehaviour
	{
		public static Action<float> ShakeEvent;

		private void OnEnable() => ShakeEvent += Shake;
		private void OnDisable() => ShakeEvent -= Shake;

		private void Shake(float magnitude)
		{
			transform.DOComplete();
			transform.DOShakePosition(0.3f, magnitude);
			transform.DOShakeRotation(0.3f, magnitude);
		}
	}
}