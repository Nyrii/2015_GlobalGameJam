using UnityEngine;
using System.Collections;

public class DestroyTuto : MonoBehaviour {

	void Start () 
    {
        Destroy(this.gameObject, 3f);
	}
}
