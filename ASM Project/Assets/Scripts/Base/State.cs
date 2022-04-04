using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM
{
	public abstract class State
	{
		private Dictionary<SubState, Action> _transitions = new Dictionary<SubState, Action>();

		public void AddTransition(SubState subState, Action callback)
		{
			_transitions.Add(subState, callback);
		}

		public virtual void Enter()
		{
			for (int i = 0; i < _transitions.Count; i++)
			{
				_transitions.ElementAt(i).Key.Enter();
			}
		}
		
		public virtual void Exit()
		{
			for (int i = 0; i < _transitions.Count; i++)
			{
				_transitions.ElementAt(i).Key.Exit();
			}
		}
		
		public virtual void Update()
		{
			for (int i = 0; i < _transitions.Count; i++)
			{
				if (_transitions.ElementAt(i).Key.Update())
				{
					_transitions.ElementAt(i).Value?.Invoke();
				}
			}
		}
	}
}