using ASM;
using UnityEngine;
using UnityEngine.Events;

namespace Tile.Explosive
{
	public class TileExplosiveStateMachine : StateMachine
	{
		[SerializeField] private UnityEvent ExplodeEvent;
		[SerializeField] private float _chargingTime;
		[SerializeField] private float _resettingTime;

		private void Awake()
		{
			State hiddenState = new HiddenState(transform);
			State visibleState = new VisibleState(transform);
			State explodedState = new ExplodedState(ExplodeEvent, transform);

			Transition playerIsFar = new PlayerIsFar(transform);
			Transition playerIsClose = new PlayerIsClose(transform);
			Transition charged = new ChargingTransition(GetComponent<MeshRenderer>(), _chargingTime);
			Transition resetted = new TimerTransition(_resettingTime);
			
			Init(initialState: hiddenState, states: new()
			{
				{hiddenState, new()
				{
					{playerIsClose, visibleState}
				}},
				{visibleState, new()
				{
					{playerIsFar, hiddenState},
					{charged, explodedState}
				}},
				{explodedState, new()
				{
					{resetted, hiddenState},
					{playerIsFar, hiddenState}
				}}
			});
		}
	}
}