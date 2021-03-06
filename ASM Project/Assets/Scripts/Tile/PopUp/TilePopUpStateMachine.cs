using System;
using System.Collections.Generic;
using ASM;

namespace Tile
{
	public class TilePopUpStateMachine : StateMachine
	{
		private void Awake()
		{
			State visibleState = new VisibleState(transform);
			State hiddenState = new HiddenState(transform);

			Transition playerIsFar = new PlayerIsFar(transform);
			Transition playerIsClose = new PlayerIsClose(transform);
			
			Init(initialState: hiddenState, states: new()
			{
				{visibleState, new() {{playerIsFar, hiddenState}}},
				{hiddenState, new() {{playerIsClose, visibleState}}}
			});
		}
	}
}