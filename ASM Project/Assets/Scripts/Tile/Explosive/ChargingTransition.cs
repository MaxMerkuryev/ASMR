using UnityEngine;

namespace Tile.Explosive
{
	public class ChargingTransition : TimerTransition
	{
		private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
		private static readonly int MainColor = Shader.PropertyToID("_Color");
		private const string EmissionColorKey = "_EMISSION";

		private MeshRenderer _renderer;
		private Color _initialColor;

		public ChargingTransition(MeshRenderer renderer, float chargingTime) : base(chargingTime)
		{
			_renderer = renderer;
			_initialColor = renderer.material.GetColor(MainColor);
		}

		public override void Enter()
		{
			base.Enter();
			_renderer.material.SetColor(MainColor, Color.red);
			_renderer.material.EnableKeyword(EmissionColorKey);
		}

		public override void Exit()
		{
			base.Exit();
			_renderer.material.SetColor(MainColor, _initialColor);
			_renderer.material.DisableKeyword(EmissionColorKey);
		}

		public override bool CheckCondition()
		{
			var intensity = Mathf.Lerp(0f, 7f, Progress);
			_renderer.material.SetColor(EmissionColor, Color.red * intensity);

			return base.CheckCondition();
		}
	}
}