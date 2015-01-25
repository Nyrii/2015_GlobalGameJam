using UnityEngine;
using System.Collections;

public class startIntro : MonoBehaviour {

    public MovieTexture texture;

    void Start()
    {
        LaunchVideo();
        Invoke("LoadNext", 18f);
    }

    void LaunchVideo()
    {
        texture.Stop();
        texture.Play();
    }

    void Update()
    {
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
