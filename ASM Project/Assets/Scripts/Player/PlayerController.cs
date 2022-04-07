using System;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _speed;
		[SerializeField] private float _rotationSpeed;
		
		public static Vector3 Position;

		private Rigidbody _rigidbody;
		private Vector3 _input = new Vector2();

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			Position = transform.position;
			HandleInput();	
			RotateTowardsMotion();
		}

		private void HandleInput()
		{
			_input.x = Input.GetAxisRaw("Horizontal");
			_input.z = Input.GetAxisRaw("Vertical");
			_input.Normalize();
		}

		private void FixedUpdate()
		{
			_rigidbody.AddForce(_input * _speed, ForceMode.Impulse);
		}

		private void RotateTowardsMotion()
		{
			if(_rigidbody.velocity == Vector3.zero) return;
			var rotation = Quaternion.Euler(0f, Quaternion.LookRotation(_rigidbody.velocity).eulerAngles.y, 0f);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed);
		}
	}
}