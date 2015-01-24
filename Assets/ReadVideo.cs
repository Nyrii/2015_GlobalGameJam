using UnityEngine;
using System.Collections;

public class ReadVideo : MonoBehaviour {
    public MovieTexture texture;
	// Use this for initialization
	void Start () 
    {
        Debug.Log(texture);
        texture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
