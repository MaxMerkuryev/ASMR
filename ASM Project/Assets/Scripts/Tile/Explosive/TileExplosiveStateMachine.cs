using System;
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
			State hiddenState = new TileHiddenState(transform);
			State visibleState = new TileVisibleState(transform);
			State explodedState = new ExplodedState(ExplodeEvent, transform);

			Transition playerIsFarTransition = new PlayerIsFarTransition(transform);
			Transition playerIsCloseTransition = new PlayerIsCloseTransition(transform);
			Transition chargingTransition = new ChargingTransition(GetComponent<MeshRenderer>(), _chargingTime);
			Transition resettingTransition = new TimeoutTransition(_resettingTime);
			
			Init(initialState: hiddenState, states: new()
			{
				{hiddenState, new()
				{
					{playerIsCloseTransition, visibleState}
				}},
				{visibleState, new()
				{
					{playerIsFarTransition, hiddenState},
					{chargingTransition, explodedState}
				}},
				{explodedState, new()
				{
					{resettingTransition, hiddenState},
					{playerIsFarTransition, hiddenState}
				}}
			});
		}
	}
}