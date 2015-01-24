using UnityEngine;
using System.Collections;

public class EventTrapWall : MonoBehaviour {
	
	public GameObject WallAnim;
	public GameObject Player;
	static float Indicate = 0;

	// Update is called once per frame
	void FixedUpdate () {
		GameObject Wall = gameObject;
		Vector2 pos = Player.transform.position; // if the player overtake the right border of the wall
		if (pos.x > Wall.transform.position.x + Wall.transform.localScale.x + 1f && Indicate == 0)
		{
			WallAnim.animation.Play("TrapWallAnim"); // then we play the animation of the wall
			Indicate = 1;
		}
		Player.transform.position = pos;
	}
}
