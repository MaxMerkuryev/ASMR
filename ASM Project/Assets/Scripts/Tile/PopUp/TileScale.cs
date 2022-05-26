using ASM;
using DG.Tweening;
using UnityEngine;

namespace Tile
{
	public abstract class TileScale : State
	{
		private Transform _transform;
		protected TileScale(Transform transform) => _transform = transform;

		protected void ScaleTo(Vector3 endScale, Ease ease)
		{
			_transform.DOKill();
			_transform.DOScale(endScale, 0.3f).SetEase(ease);
		}
	}
	
	public class VisibleState : TileScale
	{
		public VisibleState(Transform transform) : base(transform){}

		public override void Enter()
		{
			base.Enter();
			ScaleTo(new Vector3(3f, 1f, 3f), Ease.OutBack);
		}
	}
	
	public class HiddenState : TileScale
	{
		public HiddenState(Transform transform) : base(transform){}

		public override void Enter()
		{
			base.Enter();
			ScaleTo(Vector3.zero, Ease.InBack);
		}
	}
}