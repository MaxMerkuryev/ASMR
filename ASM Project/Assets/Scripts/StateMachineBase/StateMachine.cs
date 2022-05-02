using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ASM
{
	public abstract class StateMachine : MonoBehaviour
	{
		private State _currentState;

		private void SetState(State newState)
		{
			_currentState?.Exit();
			_currentState = newState;
			_currentState.Enter();
		}
		
		private void Update() => _currentState?.Update();

		protected void Init(State initialState, Dictionary<State, Dictionary<Transition, State>> states)
		{
			foreach (var state in states)
			{
				foreach (var transition in state.Value)
				{
					transition.Key.AddCallback(() => SetState(transition.Value));
					state.Key.AddTransition(transition.Key);
				}
			}
			
			SetState(initialState);
		}
	}
}