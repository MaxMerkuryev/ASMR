using System;
using ASM;

namespace Tile
{
	public class TilePopUpStateMachine : StateMachine
	{
		private void Awake()
		{
			State visibleState = new TileVisibleState(transform);
			State hiddenState = new TileHiddenState(transform);

			SubState playerIsFar = new PlayerIsFarSubState(transform);
			SubState playerIsClose = new PlayerIsCloseSubState(transform);
			
			visibleState.AddTransition(playerIsFar, () => SetState(hiddenState));
			hiddenState.AddTransition(playerIsClose, () => SetState(visibleState));
			
			SetState(hiddenState);
		}
	}
}