using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnitySampleAssets._2D;

public class BossScript : MonoBehaviour {

    public RuntimeAnimatorController[] boss;
    public GameObject bullet;
    public GameObject spawnPoint;
    public GameObject canvasVictory;
    public float shotDelay = 3f;
    float lastShot = 0;
    public int life = 100;
    int currentLife;
    public Image healthBar;
    float currentVel;
    GameObject player = null;

	void Start () 
    {
        currentLife = life;
        canvasVictory.SetActive(false);
        while (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
	    if (player.GetComponent<PlatformerCharacter2D>().karmaAmount >= 0.5)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = boss[0];
        }
        else
        {
            this.GetComponent<Animator>().runtimeAnimatorController = boss[1];
        }
	}
	
	void Update () 
    {
        lastShot -= Time.deltaTime;
        if (Random.Range(0, 10) == 9 && lastShot < 0)
        {
            lastShot = shotDelay;
            GameObject go = (GameObject) Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
            go.rigidbody2D.AddForce((player.transform.position - this.transform.position).normalized * 300F);
        }
        if (Random.Range(0, 10) == 0)
        {
            StartCoroutine(ShootLaser());
        }
        //healthBar.fillAmount = Mathf.SmoothDamp(healthBar.fillAmount, currentLife, ref currentVel, 0.5f);
        if (currentLife <= 0)
        {
            canvasVictory.SetActive(true);
        }
	}

    IEnumerator ShootLaser()
    {
        yield return new WaitForSeconds(1);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        currentLife--;
    }
}
