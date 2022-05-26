using ASM;
using UnityEngine;

namespace Tile.Explosive
{
	public class TimerTransition : Transition
	{
		private float _maxTime;
		private float _currentTime;
		
		public TimerTransition(float maxTime) => _maxTime = maxTime;		
	
		public override void Enter() => _currentTime = _maxTime;
		public override bool CheckCondition() => (_currentTime -= Time.deltaTime) <= 0f;

		public float Progress => 1f - _currentTime / _maxTime;
	}
}