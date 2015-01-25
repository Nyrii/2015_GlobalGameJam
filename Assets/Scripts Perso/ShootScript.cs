using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    //relative to the bullet instance
    public GameObject bulletPrefab;
    public GameObject spawnSpot;
    public float bulletSpeed = 100;
    public float shotDelay = 1f;
    public AudioClip shotSound;
    float lastShot = 0;
    GameObject player;

    //anim container
    private Animator anim;

	void Start () 
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
    {
        lastShot -= Time.deltaTime;
	    if (Input.GetKey(KeyCode.Space) && lastShot < 0)
        {
            audio.PlayOneShot(shotSound);
            lastShot = shotDelay;
            anim.SetBool("Shoot", true);
            GameObject go = (GameObject) Instantiate(bulletPrefab, spawnSpot.transform.position, Quaternion.identity);
            //sets the rotation based on player scale
            Vector2 newScale = new Vector2((player.transform.localScale.x < 0) ? -1 : 1, go.transform.localScale.y);
            go.transform.localScale = newScale;
            go.rigidbody2D.AddForce(new Vector2(bulletSpeed * newScale.x, 0f));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Shoot", false);
        }
	}
}
