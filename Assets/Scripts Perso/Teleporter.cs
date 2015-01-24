using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public float 				activationDelay = 3;
	[HideInInspector]
	public float 				lastActivation = 0;
	public GameObject 		pairedTeleporter;
	GameObject 				player;

	void Start () 
	{
		if (pairedTeleporter == null)
		{
			Debug.LogError("No pair");
			return;
		}
	}
	
	void Update () 
	{
		lastActivation -= Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (lastActivation <= 0)
		{
			this.transform.GetChild(0).particleSystem.Play();
			player = col.gameObject;
			col.gameObject.SetActive(false);
			Invoke("Teleport", 2f);
		}
	}

	void Teleport ()
	{
		if (player != null)
		{
			lastActivation = activationDelay;
			pairedTeleporter.GetComponent<Teleporter>().transform.GetChild(0).gameObject.transform.particleSystem.Play();
			pairedTeleporter.GetComponent<Teleporter>().lastActivation = activationDelay;  //could also set different teleporting timer, so we would have to get the variable
			player.SetActive(true);
			player.transform.position = pairedTeleporter.transform.position;
		}
	}
}
