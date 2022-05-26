using UnityEngine;
using UnityEngine.Events;

namespace Tile.Explosive
{
	public class ExplodedState : HiddenState
	{
		private UnityEvent _event;

		public ExplodedState(UnityEvent @event, Transform transform) : base(transform)
		{
			_event = @event;
		}

		public override void Enter()
		{
			_event?.Invoke();
			base.Enter();
		}
	}
}