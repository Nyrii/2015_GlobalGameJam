using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]

public class PlayerPersoScript : MonoBehaviour {

	Animator anim;
	public float MoveSpeed = 10f;
	int runAnim = Animator.StringToHash("PlayerVelocity");

	void Start () 
	{
		anim = this.GetComponent<Animator>();
	}

	float horizontalVel;
	void Update () 
	{
		horizontalVel = Input.GetAxis("Horizontal");
		float scaleX = (horizontalVel < 0) ? -1 : 1; 
		transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
		anim.SetFloat(runAnim, Mathf.Abs(horizontalVel));
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2(MoveSpeed * horizontalVel, 0);
	}
}
