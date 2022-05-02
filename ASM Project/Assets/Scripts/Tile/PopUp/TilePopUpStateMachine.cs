using System;
using System.Collections.Generic;
using ASM;

namespace Tile
{
	public class TilePopUpStateMachine : StateMachine
	{
		private void Awake()
		{
			State visibleState = new TileVisibleState(transform);
			State hiddenState = new TileHiddenState(transform);

			Transition playerIsFar = new PlayerIsFarTransition(transform);
			Transition playerIsClose = new PlayerIsCloseTransition(transform);
			
			Init(initialState: hiddenState, states: new()
			{
				{visibleState, new() {{playerIsFar, hiddenState}}},
				{hiddenState, new() {{playerIsClose, visibleState}}}
			});
		}
	}
}