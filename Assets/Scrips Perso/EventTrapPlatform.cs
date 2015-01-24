using UnityEngine;
using System.Collections;

public class EventTrapPlatform : MonoBehaviour {
	
	public GameObject Platform02;
	public GameObject Player;
	static float Indicate = 0;
	GameObject Platform01;

	void Start()
	{
		Platform01 = gameObject;
	}

	// Update is called once per frame
	void Update () {
		Vector2 pos = Player.transform.position;
		if ((pos.y > Platform01.transform.position.y) && (pos.x > Platform01.transform.position.x)
		    && (pos.x < Platform02.transform.position.x + (Platform02.transform.localScale.x / 2)) && Indicate == 0)
		{
			Platform01.animation.Play("TrapFallAnim");
			Platform02.animation.Play("TrapFallAnim02");
			Invoke("StopAnimPlatform01", Platform01.animation.clip.length + 0.345f);
			Invoke ("StopAnimPlatform02", Platform02.animation.clip.length + 0.345f);
			Indicate = 1;
		}
		Player.transform.position = pos;
	}

	void StopAnimPlatform01()
	{
		Platform01.animation.Stop ("TrapFallAnim");
	}

	void StopAnimPlatform02()
	{
		Platform02.animation.Stop ("TrapFallAnim02");
	}
}