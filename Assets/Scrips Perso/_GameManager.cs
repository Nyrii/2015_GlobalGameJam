using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class _GameManager : MonoBehaviour {

    public int isPlaying;
    //Player components
    GameObject player;
    PlatformerCharacter2D playerControl;

    //menu components for pause or quit
    public GameObject canvasObj;
    public GameObject resumeText;

    void Start()
    {
        isPlaying = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlatformerCharacter2D>();
        canvasObj.SetActive(false);
        resumeText.SetActive(false);
    }

    void Update()
    {
        if (playerControl.health < 0)
        {
            Destroy(player);
            canvasObj.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Tab) && playerControl.health > 0)
        {
            isPlaying = (isPlaying == 0) ? 1 : 0;
            if (isPlaying == 0)
            {
                canvasObj.SetActive(true);
                resumeText.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvasObj.SetActive(false);
                resumeText.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void pauseMenuOnDeath(int choice)
    {
        //1 = reload
        //0 = menu
        //-1 = quit
        isPlaying = 0;
        if (choice == 1)
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }
        else if (choice == 0)
        {
            Time.timeScale = 1;
            Application.LoadLevel("MainMenu");
        }
        else if (choice == -1)
        {
            Time.timeScale = 1;
            Application.Quit();
        }
    }

}
