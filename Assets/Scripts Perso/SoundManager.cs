using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    float karma;
    float currentMusicTime = 0;
    int index;
    public GameObject KarmaGauge;
    public AudioClip[] musics;

    void Start () 
    {
        index = 4;
        audio.clip = musics[index];
        audio.Play();
        audio.loop = true;
        karma = Karma.karmaAmount;
	}
	
	void Update () 
    {
        karma = Karma.karmaAmount;
	    if (karma <= 0.6 && karma >= 0.4 && index != 1 && Time.timeSinceLevelLoad > 6)
        {
            audio.Pause();
            if (index != 4)
                currentMusicTime = audio.time;
            index = 1;
            audio.clip = musics[index];
            audio.time = currentMusicTime;
            audio.Play();
        }
        else if (karma > 0.6 && karma < 0.8 && index != 2)
        {
            audio.Pause();
            currentMusicTime = audio.time;
            index = 2;
            audio.clip = musics[index];
            audio.time = currentMusicTime;
            audio.Play();
        }
        else if (karma >= 0.8 && index != 3)
        {
            audio.Pause();
            currentMusicTime = audio.time;
            index = 3;
            audio.clip = musics[index];
            audio.time = currentMusicTime;
            audio.Play();
        }
	}
}
