using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class SoundManager : MonoBehaviour {

    float karma;
    float currentMusicTime = 0;
    int index;
    public AudioClip[] musics;
    public _GameManager gm;

    void Start () 
    {
        gm = GameObject.Find("_GameManager").GetComponent<_GameManager>();
        index = 4;
        audio.clip = musics[index];
        audio.Play();
        audio.loop = true;
        karma = Karma.karmaAmount;
	}
	
	void Update () 
    {
        //karma = Karma.karmaAmount;
        karma = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>().karmaAmount;
        Debug.Log(karma);
	    if (karma <= 0.6 && karma >= 0.4 && index != 1 && Time.timeSinceLevelLoad > 6)
        {
            gm.SwitchCharacter(0);
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
            gm.SwitchCharacter(3);
            audio.Pause();
            currentMusicTime = audio.time;
            index = 2;
            audio.clip = musics[index];
            audio.time = currentMusicTime;
            audio.Play();
        }
        else if (karma >= 0.8 && index != 3)
        {
            gm.SwitchCharacter(4);
            audio.Pause();
            currentMusicTime = audio.time;
            index = 3;
            audio.clip = musics[index];
            audio.time = currentMusicTime;
            audio.Play();
        }
        else if (karma < 0.4 && karma >= 0.2 && index != 5)
        {
            gm.SwitchCharacter(1);
            audio.Pause();
            currentMusicTime = audio.time;
            index = 5;
            audio.clip = musics[index];
            audio.time = currentMusicTime;
            audio.Play();
        }
        else if (karma < 0.2 & index != 6)
        {
            gm.SwitchCharacter(2);
            audio.Pause();
            currentMusicTime = audio.time;
            index = 6;
            audio.clip = musics[index];
            audio.time = currentMusicTime;
            audio.Play();
        }
	}
}
