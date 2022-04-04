using UnityEngine;

namespace ASM
{
	public abstract class StateMachine : MonoBehaviour
	{
		private State _currentState;

		protected void SetState(State newState)
		{
			_currentState?.Exit();
			_currentState = newState;
			_currentState.Enter();
		}

		private void Update() => _currentState?.Update();
	}
}