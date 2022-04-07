using System;
using UnityEngine;

namespace Misc
{
	public class BoxFrame : MonoBehaviour
	{
		[SerializeField] private Color _color = Color.red;
		
		private void OnDrawGizmos()
		{
			Gizmos.color = _color;
			Gizmos.DrawWireCube(transform.position, transform.localScale);

			Gizmos.color = _color - new Color(0f,0f,0f, 0.5f);
			Gizmos.DrawCube(transform.position, transform.localScale);
		}
	}
}