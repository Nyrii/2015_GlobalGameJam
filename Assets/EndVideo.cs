using UnityEngine;
using System.Collections;

public class EndVideo : MonoBehaviour {

    public MovieTexture texture;

    void Start()
    {
        LaunchVideo();
        Invoke("LoadNext", 10f);
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
        Application.Quit();
    }
}
