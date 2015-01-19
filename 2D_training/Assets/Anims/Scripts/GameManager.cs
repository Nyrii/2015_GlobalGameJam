using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager 	GM;
	public GameObject 			GameOverOverlay;
	public GameObject 			playerInstance;
	public Transform 			SpawnPoint;
	
	void Start () 
	{
		if (GM == null)
		{
			GM = this.GetComponent<GameManager>();
		}
	}
	
	void Update () {
	
	}

	public void resetLevel()
	{
		GameOverOverlay.SetActive(true);
	}

	public void Respawn()
	{
		//Display game over screen
		GameOverOverlay.SetActive(false);
		GameObject.Find("Image").GetComponent<HealthBar>().currentHealth = 1;
		Instantiate(playerInstance, SpawnPoint.position, SpawnPoint.rotation);
	}
}
