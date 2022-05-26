using ASM;
using Player;
using UnityEngine;

namespace Tile
{
	public abstract class DistanceToPlayer : Transition
	{
		private Transform _origin;
		
		protected const float _maxDistance = 15f;
		protected float _distance => Vector3.Distance(_origin.position, PlayerController.Position);

		protected DistanceToPlayer(Transform origin) => _origin = origin;
	}
	
	public class PlayerIsFar : DistanceToPlayer
	{
		public PlayerIsFar(Transform origin) : base(origin){}
		public override bool CheckCondition() => _distance > _maxDistance;
	}
	
	public class PlayerIsClose : DistanceToPlayer
	{
		public PlayerIsClose(Transform origin) : base(origin){}
		public override bool CheckCondition() => _distance <= _maxDistance;
	}
}