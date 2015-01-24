using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    float karma;
    public GameObject KarmaGauge;
    public AudioClip[] musics;

    void Start () 
    {
        audio.clip = musics[0];
        audio.Play();
        audio.loop = true;
        karma = Karma.karmaAmount;
	}
	
	void Update () 
    {
	    if (karma <= 0.6 && karma >= 0.4)
        {
            audio.clip = musics[0];
        }
        //add amounts
	}
}
