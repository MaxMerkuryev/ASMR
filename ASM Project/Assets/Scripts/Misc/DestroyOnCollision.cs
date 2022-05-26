using System;
using UnityEngine;

namespace Misc
{
	public class DestroyOnCollision : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision) => Destroy(gameObject);
	}
}