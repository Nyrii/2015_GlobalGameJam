using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Teleporter : MonoBehaviour {

	public float 				activationDelay = 3;
	PlatformerCharacter2D tmpKarma;
	[HideInInspector]
	public float 				lastActivation = 0;
	public GameObject 		pairedTeleporter;
	public float				Indicator = -1;
	GameObject 				player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (pairedTeleporter == null)
		{
			Debug.LogError("No pair");
			return;
		}
		tmpKarma = player.GetComponent<PlatformerCharacter2D>();
	}
	
	void Update () 
	{
		lastActivation -= Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
        Debug.Log(tmpKarma.karmaAmount);
		if (tmpKarma.karmaAmount < 0.5f && Indicator == 0 || tmpKarma.karmaAmount >= 0.5f && Indicator == 1)
			if (lastActivation <= 0)
			{
				//this.transform.GetChild(0).particleSystem.Play();
				player = col.gameObject;
				col.gameObject.SetActive(false);
				Invoke("Teleport", 0.5f);
			}
	}

	void Teleport ()
	{
		if (player != null)
		{
			lastActivation = activationDelay;
			//pairedTeleporter.GetComponent<Teleporter>().transform.GetChild(0).gameObject.transform.particleSystem.Play();
			pairedTeleporter.GetComponent<Teleporter>().lastActivation = activationDelay;  //could also set different teleporting timer, so we would have to get the variable
			player.SetActive(true);
			player.transform.position = pairedTeleporter.transform.position;
		}
	}
}
