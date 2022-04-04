using ASM;
using Player;
using UnityEngine;

namespace Tile
{
	public abstract class DistanceCheckSubState : SubState
	{
		private Transform _origin;
		protected const float _maxDistance = 15f;

		protected DistanceCheckSubState(Transform origin) => _origin = origin;
		protected float DistanceToPlayer => Vector3.Distance(_origin.position, PlayerController.Position);
	}
	
	public class PlayerIsFarSubState : DistanceCheckSubState
	{
		public PlayerIsFarSubState(Transform origin) : base(origin){}
		public override bool Update() => DistanceToPlayer > _maxDistance;
	}
	
	public class PlayerIsCloseSubState : DistanceCheckSubState
	{
		public PlayerIsCloseSubState(Transform origin) : base(origin){}
		public override bool Update() => DistanceToPlayer <= _maxDistance;
	}
}