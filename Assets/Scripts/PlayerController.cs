using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	// Fisics body
	private Rigidbody _rig;

	private IObservable<Vector3> _movement;
	private BoolReactiveProperty _isJump = new BoolReactiveProperty();

	private Animator _anim;

	// Use this for initialization
	void Start ()
	{
		// Rigidbody
		_rig = GetComponent<Rigidbody>();
		
		// Animatior
		_anim = GetComponent<Animator>();
		
		_movement = this.FixedUpdateAsObservable()
			.Select(unit =>
			{
				// Move (turn)
				var x = Input.GetAxis("Horizontal");
				transform.localRotation = Quaternion.Euler(0, x * 20, 0);
				
				// Run
				var y = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);

				// Jump
				_isJump.Value = Input.GetAxis("Jump") != 0;
				
				// Animations
				_anim.SetFloat("Speed", y);
				_anim.SetFloat("height", transform.position.y);
				
				return new Vector3(x, 0, y);
			});
		
		_movement.Where(vector3 => vector3 != Vector3.zero)
			.Subscribe((vector3) =>
			{
//				 _rig.AddForce(vector3 * 1000);
				transform.Translate(vector3 * 0.1f);
			});

		_isJump.Subscribe(b =>
		{
			_anim.SetBool("isJump", b);
			if (transform.position.y < 0.1f)
			{
				_rig.AddForce(Vector3.up * 10000);
			}
		});
	}
	
}
