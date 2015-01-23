using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class _GameManager : MonoBehaviour {

    //Player components
    GameObject player;
    PlatformerCharacter2D playerControl;

    //menu components for pause or quit
    public GameObject canvasObj;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlatformerCharacter2D>();
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

    public void pauseMenu(int choice)
    {
        //1 = reload
        //0 = menu
        //-1 = quit
        if (choice == 1)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else if (choice == 0)
        {
            Application.LoadLevel("MainMenu");
        }
        else if (choice == -1)
        {
            Application.Quit();
        }
    }

}
