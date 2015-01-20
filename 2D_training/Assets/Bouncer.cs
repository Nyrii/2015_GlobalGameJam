using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log("COLLISION");
		if (col.gameObject.tag == "Player")
		{
			float verticalVel =0;//= col.gameObject.rigidbody2D.velocity.y;
			verticalVel += 10f;
			col.gameObject.rigidbody2D.velocity = new Vector2(col.gameObject.rigidbody2D.velocity.x, verticalVel);
		}
	}
}
