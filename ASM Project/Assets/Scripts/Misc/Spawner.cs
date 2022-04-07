using UnityEngine;

namespace Misc
{
	public class Spawner : MonoBehaviour
	{
		public void Spawn(GameObject @object) => Instantiate(@object, transform.position, Quaternion.identity);
	}
}