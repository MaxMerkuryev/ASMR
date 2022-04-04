namespace ASM
{
	public abstract class SubState
	{
		public virtual void Enter(){}
		public virtual void Exit(){}
		
		public abstract bool Update();
	}
}