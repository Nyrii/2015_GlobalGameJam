using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	GameObject playerInstance = null;
	Vector3 currentVelocity = Vector3.zero;

	void Start () {
		playerInstance = GameObject.FindGameObjectWithTag("TEST");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInstance == null)
		{
			playerInstance = GameObject.FindGameObjectWithTag("TEST");
		}
		else
		{
			Vector3 target = new Vector3(playerInstance.transform.position.x,
			                             playerInstance.transform.position.y,
			                             this.transform.position.z);
			this.transform.position = Vector3.SmoothDamp(transform.position, 
			                                             target,
			                                             ref currentVelocity,
			                                             0.2f);
		}
	}
}
