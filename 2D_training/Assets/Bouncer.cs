using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	public class Stuff
	{
		public int bullets;
		public int grenades;
		public int rockets;
		public float fuel;
		
		public Stuff(int bul, int gre, int roc)
		{
			bullets = bul;
			grenades = gre;
			rockets = roc;
		}
		
		public Stuff(int bul, float fu)
		{
			bullets = bul;
			fuel = fu;
		}
		
		// Constructor
		public Stuff ()
		{
			bullets = 1;
			grenades = 1;
			rockets = 1;
		}
	}

	float verticalVel;
	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log("Collided at "+ col.contacts[0].point);
		if (col.gameObject.tag == "Player")
		{
			verticalVel = 600f;
			col.gameObject.rigidbody2D.AddForce(new Vector2(0 , verticalVel));
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (col.gameObject.rigidbody2D.velocity != new Vector2(col.gameObject.rigidbody2D.velocity.x, verticalVel))
		{
			//col.gameObject.rigidbody2D.velocity = new Vector2(col.gameObject.rigidbody2D.velocity.x, verticalVel);
		}
	}
}
