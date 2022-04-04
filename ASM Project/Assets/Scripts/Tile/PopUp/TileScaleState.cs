using ASM;
using DG.Tweening;
using UnityEngine;

namespace Tile
{
	public abstract class TileScaleState : State
	{
		private Transform _transform;
		protected TileScaleState(Transform transform) => _transform = transform;

		protected void PopUp(Vector3 endScale, Ease ease)
		{
			_transform.DOKill();
			_transform.DOScale(endScale, 0.3f).SetEase(ease);
		}
	}
	
	public class TileVisibleState : TileScaleState
	{
		public TileVisibleState(Transform transform) : base(transform){}

		public override void Enter()
		{
			base.Enter();
			PopUp(new Vector3(3f, 1f, 3f), Ease.OutBack);
		}
	}
	
	public class TileHiddenState : TileScaleState
	{
		public TileHiddenState(Transform transform) : base(transform){}

		public override void Enter()
		{
			base.Enter();
			PopUp(Vector3.zero, Ease.InBack);
		}
	}
}