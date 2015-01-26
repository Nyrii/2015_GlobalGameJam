using UnityEngine;
using System;
using System.Collections;

public class startIntro : MonoBehaviour {

    public MovieTexture texture;
	bool videoIsPlaying = false;

    void Start()
    {
        Invoke("LoadNext", 18f);
    }

    void LaunchVideo()
    {
		try
		{
			texture.Stop();
			texture.Play();
		}
		catch (Exception toto)
		{
			Debug.Log(toto);
			Application.LoadLevel("level1Bis");
		}
    }

    void Update()
    {
		if (!videoIsPlaying && Time.timeSinceLevelLoad > 1)
		{		
			videoIsPlaying = true;
			LaunchVideo();
		}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNext();
        }
    }

    void LoadNext()
    {
        Application.LoadLevel("level1Bis");
    }
}
