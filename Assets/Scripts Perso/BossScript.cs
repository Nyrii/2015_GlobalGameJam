using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnitySampleAssets._2D;

public class BossScript : MonoBehaviour {

    public RuntimeAnimatorController[] boss;
    public GameObject bullet;
    public GameObject spawnPoint;
    public GameObject canvasVictory;
    public int life = 100;
    int currentLife;
    public Image healthBar;
    float currentVel;
    GameObject player;

	void Start () 
    {
        currentLife = life;
        canvasVictory.SetActive(false);
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
        if (Random.Range(0, 10) == 10)
        {
            GameObject go = (GameObject) Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
            this.rigidbody2D.AddForce(player.transform.position - this.transform.position);
        }
        if (Random.Range(0, 10) == 0)
        {
            StartCoroutine(ShootLaser());
        }
        healthBar.fillAmount = Mathf.SmoothDamp(healthBar.fillAmount, currentLife, ref currentVel, 0.5f);
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
