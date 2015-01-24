using UnityEngine;
using System.Collections;

public class ReadVideo : MonoBehaviour {

    public MovieTexture texture;

    void Start () 
    {
        InvokeRepeating("LaunchVideo", 0, 5.9f);
	}
	
	void LaunchVideo()
    {
        texture.Stop();
        Debug.Log("TOTO");
        texture.Play();
    }
}
