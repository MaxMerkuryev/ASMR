using ASM;

namespace Tile
{
	public class TileReversedStateMachine : StateMachine
	{
		private void Awake()
		{
			State visibleState = new VisibleState(transform);
			State hiddenState = new HiddenState(transform);

			Transition playerIsFar = new PlayerIsFar(transform);
			Transition playerIsClose = new PlayerIsClose(transform);
			
			Init(initialState: hiddenState, states: new()
			{
				{visibleState, new() {{playerIsClose, hiddenState}}},
				{hiddenState, new() {{playerIsFar, visibleState}}}
			});
		}
	}
}