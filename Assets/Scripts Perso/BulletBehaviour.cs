using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    void Update()
    {
        if (Camera.main.WorldToScreenPoint(this.transform.position).x > Screen.width || Camera.main.WorldToScreenPoint(this.transform.position).x < 0)
        {
            Destroy(this.gameObject);
        }
    }

	void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
