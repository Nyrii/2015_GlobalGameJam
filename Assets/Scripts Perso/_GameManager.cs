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
    //RuntimeAnimatorController currentAnim;
    public RuntimeAnimatorController[] allAnims;

    float lastPause = 1;
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
        lastPause -= Time.deltaTime;
        if (playerControl.health < 0)
        {
            Destroy(player);
            canvasObj.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Tab) && playerControl.health > 0 && lastPause < 0)
        {
            isPlaying = !isPlaying;
            if (!isPlaying)
            {
                lastPause = 1;
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
        lastPause = -1;
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
        if (player != null)
        {
            switch (index)
            {
                case 0:
                    player.GetComponent<Animator>().runtimeAnimatorController = allAnims[0];
                    player.GetComponent<ShootScript>().bulletPrefab = bulletPrefabs[0];
                    player.GetComponent<PlatformerCharacter2D>().maxSpeed = 10f;
                    player.GetComponent<PlatformerCharacter2D>().jumpForce = 400f;
                    break;
                case 1:
                    player.GetComponent<Animator>().runtimeAnimatorController = allAnims[1];
                    player.GetComponent<ShootScript>().bulletPrefab = bulletPrefabs[1];
                    player.GetComponent<PlatformerCharacter2D>().maxSpeed = 8f;
                    player.GetComponent<PlatformerCharacter2D>().jumpForce = 380f;
                    break;
                case 2:
                    player.GetComponent<Animator>().runtimeAnimatorController = allAnims[2];
                    player.GetComponent<ShootScript>().bulletPrefab = bulletPrefabs[1];
                    player.GetComponent<PlatformerCharacter2D>().maxSpeed = 3f;
                    player.GetComponent<PlatformerCharacter2D>().jumpForce = 300f;
                    break;
            }
        }
    }
}
