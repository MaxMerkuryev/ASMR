using ASM;
using UnityEngine;

namespace Tile.Explosive
{
	public class TimeoutTransition : Transition
	{
		private float _maxTime;
		private float _currentTime;
		
		public TimeoutTransition(float maxTime) => _maxTime = maxTime;		

		public float Progress => 1f - _currentTime / _maxTime;
		
		public override void Enter() => _currentTime = _maxTime;
		public override bool CheckCondition() => (_currentTime -= Time.deltaTime) <= 0f;
	}
}