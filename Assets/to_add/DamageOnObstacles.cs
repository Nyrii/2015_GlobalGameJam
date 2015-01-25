using UnityEngine;
using System.Collections;

public class DamageOnObstacles : MonoBehaviour {

	public GameObject Player;
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		die(col.gameObject);
	}

	void die(GameObject Player)
	{
		Destroy(Player);
	}
}
