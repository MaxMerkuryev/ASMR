using System;

namespace ASM
{
	public abstract class Transition
	{
		public Action Callback;
		
		public abstract bool CheckCondition();

		public virtual void Enter(){}
		public virtual void Exit(){}
		
		public void Update()
		{
			if (!CheckCondition()) return;

			if (Callback != null)
			{
				Callback.Invoke();
			}
			else
			{
				Enter();
			}
		}
	}
}