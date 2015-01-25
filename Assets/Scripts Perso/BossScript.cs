using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnitySampleAssets._2D;

public class BossScript : MonoBehaviour {

    public RuntimeAnimatorController[] boss;
    public GameObject bullet;
    public GameObject spawnPoint;
    public GameObject canvasVictory;
    public GameObject[] canvas;
    public float shotDelay = 3f;
    float lastShot = 0;
    public float life = 1;
    float currentLife;
    Image healthBar;
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
            canvas[1].SetActive(false);
            this.GetComponent<Animator>().runtimeAnimatorController = boss[0];
        }
        else
        {
            canvas[0].SetActive(false);
            this.GetComponent<Animator>().runtimeAnimatorController = boss[1];
        }
        healthBar = GameObject.Find("GaugeIn").GetComponent<Image>();
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
        healthBar.fillAmount = Mathf.SmoothDamp(healthBar.fillAmount, currentLife, ref currentVel, 0.5f);
        if (currentLife <= 0)
        {
            canvasVictory.SetActive(true);
            healthBar.fillAmount = 0;
            Destroy(this.gameObject);
        }
	}

    IEnumerator ShootLaser()
    {
        yield return new WaitForSeconds(1);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(currentLife);
        currentLife -= 0.1f;
    }
}
