using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class _GameManager : MonoBehaviour {

    [HideInInspector]
    public bool isPlaying;

    //Player components
    public GameObject [] bulletPrefabs;
    GameObject player;
    PlatformerCharacter2D playerControl;

    //menu components for pause or quit
    public GameObject canvasObj;
    public GameObject pauseMenu;
    public GameObject resumeText;

    //get player controllers
    RuntimeAnimatorController currentAnim;
    public RuntimeAnimatorController[] allAnims;

    void Awake()
    {
        isPlaying = true;
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
            isPlaying = !isPlaying;
            if (!isPlaying)
            {
                canvasObj.SetActive(true);
                resumeText.SetActive(true);
                pauseMenu.GetComponent<Animation>().Play("MenuInAnim");
                Invoke("SetTimeScale", 0.5f);
            }
            else
            {
                pauseMenu.GetComponent<Animation>().Play("MenuOutAnim");
                Time.timeScale = 1;
            }
        }
    }


    void SetTimeScale()
    {
        Time.timeScale = 0;
    }

    public void pauseMenuOnDeath(int choice)
    {
        //1 = reload
        //0 = menu
        //-1 = quit
        isPlaying = false;
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


    public void SwitchCharacter(int index)
    {
        currentAnim = player.GetComponent<Animator>().runtimeAnimatorController;
        switch (index)
        {
            case 0:
                player.GetComponent<Animator>().runtimeAnimatorController = allAnims[0];
                player.GetComponent<ShootScript>().bulletPrefab = bulletPrefabs[0];
                break;
            case 1:
                player.GetComponent<Animator>().runtimeAnimatorController = allAnims[1];
                player.GetComponent<ShootScript>().bulletPrefab = bulletPrefabs[1];
                break;
        }
    }
}
