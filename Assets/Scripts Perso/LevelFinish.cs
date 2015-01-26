using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
		GameObject.Find("KarmaKeeper").GetComponent<KarmaKeeper>().karmaSaved = 
			GameObject.FindGameObjectWithTag("Player").GetComponent<UnitySampleAssets._2D.PlatformerCharacter2D>().karmaAmount;
        Application.LoadLevel("LevelBoss");
    }
}
