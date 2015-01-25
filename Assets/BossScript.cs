using UnityEngine;
using System.Collections;    
using UnitySampleAssets._2D;

public class BossScript : MonoBehaviour {

    public GameObject[] boss;
    GameObject player;

	// Use this for initialization
	void Start () 
    {
	    if (player.GetComponent<PlatformerCharacter2D>().karmaAmount >= 0.5)
        {
            Instantiate(boss[0]);
        }
        else
        {
            Instantiate(boss[1]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
