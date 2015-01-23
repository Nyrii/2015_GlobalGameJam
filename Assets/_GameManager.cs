using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class _GameManager : MonoBehaviour {

    //Player components
    GameObject player;
    PlatformerCharacter2D playerControl;

    //menu components for pause or quit
    GameObject canvasObj;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvasObj = GameObject.FindGameObjectWithTag("Canvas");
        playerControl = playerControl.GetComponent<PlatformerCharacter2D>();
        canvasObj.SetActive(false);
    }

    void Update()
    {
        if (playerControl.health < 0)
        {
            Destroy(player);
            canvasObj.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
