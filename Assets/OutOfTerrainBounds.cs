using UnityEngine;
using System.Collections;

public class OutOfTerrainBounds : MonoBehaviour {

	public GameObject	OtherLimit;

	GameObject				player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (player != null && OtherLimit != null)
		{
			player.rigidbody2D.velocity = Vector2.zero;
			player.transform.position = OtherLimit.transform.position + Vector3.up * 3f;
			player.GetComponent<UnitySampleAssets._2D.Platformer2DUserControl>().enabled = false;
			player.rigidbody2D.velocity = OtherLimit.transform.up * 15f;
			Invoke("ResumeControl", 1f);
		}
	}

	void ResumeControl()
	{
		player.GetComponent<UnitySampleAssets._2D.Platformer2DUserControl>().enabled = true;
	}
}
