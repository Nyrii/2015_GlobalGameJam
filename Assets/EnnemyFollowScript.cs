using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class EnnemyFollowScript : MonoBehaviour {

    public int ennemyLives = 1;

    GameObject player;
    GameObject GM;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GM = GameObject.Find("_GameManager");
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Vector2 distance = player.transform.position - this.transform.position;
            if (distance.x < 10 && distance.x > -10)
            {
                this.transform.localScale = new Vector3((distance.x > 0) ? 1 : -1, transform.localScale.y, 1);
                this.rigidbody2D.velocity = new Vector2(6f * transform.localScale.x, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Debug.LogWarning("Display menu here");
            //TODO: disp menu
        }
        else if (col.gameObject.tag == "Bullet")
        {
            //Destroy(col.gameObject);
            player.GetComponent<PlatformerCharacter2D>().karmaAmount -= 0.1f;
            Destroy(this.gameObject);
        }
    }
}
