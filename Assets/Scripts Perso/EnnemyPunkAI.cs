using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class EnnemyPunkAI : MonoBehaviour {

    public GameObject bottlePrefab;
    public GameObject shootPosition;
    public float bottleVelocity = 10f;
    public float bottleTorque = 10f;
    GameObject player;
    Animator anim;

    void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        StartCoroutine(MoveAlong());
	}
	
	void Update () 
    {
        anim.SetFloat("Velocity", Mathf.Abs(this.rigidbody2D.velocity.x));
        if (rigidbody2D.velocity.x != 0)
            this.transform.localScale = new Vector3((rigidbody2D.velocity.x > 0) ? 1 : -1, transform.localScale.y, 1);
        RaycastHit2D ray = Physics2D.Raycast(this.gameObject.transform.position, player.transform.position - this.transform.position);
        if (ray.collider != null && ray.collider.gameObject.tag == "Player")
        {
            GameObject go = (GameObject) Instantiate(bottlePrefab, shootPosition.transform.position, Quaternion.identity);
            go.rigidbody2D.AddForce((player.transform.position - this.transform.position) * bottleVelocity);
            go.rigidbody2D.AddTorque(bottleTorque);
        }
	}

    IEnumerator MoveAlong()
    {
        while (true)
        {
            this.rigidbody2D.velocity = new Vector2(4, 0);
            yield return new WaitForSeconds(2);
            this.rigidbody2D.velocity = new Vector2(-4, 0);
            yield return new WaitForSeconds(2);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Debug.LogWarning("MENU HERE");
        }
        else if (col.gameObject.tag == "Bullet")
        {
            player.GetComponent<PlatformerCharacter2D>().karmaAmount -= 0.1f;
            Destroy(this.gameObject);
        }
    }
}
