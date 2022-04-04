using System;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		public static Vector3 Position;

		private void Update()
		{
			Position = transform.position;
		}
	}
}