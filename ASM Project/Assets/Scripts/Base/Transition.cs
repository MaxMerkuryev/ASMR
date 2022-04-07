namespace ASM
{
	public abstract class Transition
	{
		public virtual void Enter(){}
		public virtual void Exit(){}
		
		public abstract bool Update();
	}
}