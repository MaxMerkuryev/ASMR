using System;

namespace ASM
{
	public abstract class Transition
	{
		public abstract bool CheckCondition();
		
		private Action _callback;
		public void AddCallback(Action callback) => _callback = callback;
		
		public virtual void Enter(){}
		public virtual void Exit(){}
		
		public void Update()
		{
			if (!CheckCondition()) return;

			if (_callback != null)
			{
				_callback.Invoke();
			}
			else
			{
				Enter();
			}
		}
	}
}