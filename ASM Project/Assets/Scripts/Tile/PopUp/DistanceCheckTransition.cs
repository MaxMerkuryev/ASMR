using ASM;
using Player;
using UnityEngine;

namespace Tile
{
	public abstract class DistanceCheckTransition : Transition
	{
		private Transform _origin;
		protected const float _maxDistance = 15f;

		protected DistanceCheckTransition(Transform origin) => _origin = origin;
		protected float DistanceToPlayer => Vector3.Distance(_origin.position, PlayerController.Position);
	}
	
	public class PlayerIsFarTransition : DistanceCheckTransition
	{
		public PlayerIsFarTransition(Transform origin) : base(origin){}
		public override bool CheckCondition() => DistanceToPlayer > _maxDistance;
	}
	
	public class PlayerIsCloseTransition : DistanceCheckTransition
	{
		public PlayerIsCloseTransition(Transform origin) : base(origin){}
		public override bool CheckCondition() => DistanceToPlayer <= _maxDistance;
	}
}