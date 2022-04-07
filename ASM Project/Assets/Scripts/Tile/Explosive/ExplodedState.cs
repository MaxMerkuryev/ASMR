using ASM;
using UnityEngine;
using UnityEngine.Events;

namespace Tile.Explosive
{
	public class ExplodedState : TileHiddenState
	{
		private UnityEvent ExplodeEvent;

		public ExplodedState(UnityEvent explodeEvent, Transform transform) : base(transform)
		{
			ExplodeEvent = explodeEvent;
		}

		public override void Enter()
		{
			ExplodeEvent?.Invoke();
			base.Enter();
		}
	}
}