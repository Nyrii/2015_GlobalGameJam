using UnityEngine;
using System.Collections;

public class BottleDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, 3f);
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            Application.LoadLevel(Application.loadedLevel);
            Debug.LogWarning("END HERE");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
