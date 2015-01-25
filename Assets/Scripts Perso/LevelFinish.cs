using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        Application.LoadLevel("LevelBoss");
    }
}
