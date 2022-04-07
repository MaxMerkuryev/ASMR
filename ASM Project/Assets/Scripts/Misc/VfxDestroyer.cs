using System;
using UnityEngine;

namespace Misc
{
	[RequireComponent(typeof(ParticleSystem))]
	public class VfxDestroyer : MonoBehaviour
	{
		private ParticleSystem.MainModule _particleSystem;

		private void Awake() => _particleSystem = GetComponent<ParticleSystem>().main;
		private void OnEnable() => Invoke(nameof(DestroySelf), _particleSystem.duration);
		private void DestroySelf() => Destroy(gameObject);
	}
}