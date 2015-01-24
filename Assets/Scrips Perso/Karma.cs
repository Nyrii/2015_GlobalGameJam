using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnitySampleAssets._2D;

public class Karma : MonoBehaviour {

    public static float karmaAmount = 0.5f;
    float DecreaseVel;
    private Image karmaEvilGauge;
    private Image karmaGoodGauge;
    _GameManager gm;
    PlatformerCharacter2D playerStats;

    void Start()
    {
        gm = GameObject.Find("_GameManager").GetComponent<_GameManager>();
        //gets the two gauges which are children
        karmaEvilGauge = gameObject.transform.GetChild(0).GetComponent<Image>();
        karmaGoodGauge = gameObject.transform.GetChild(1).GetComponent <Image>();
        //gets the player;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();
    }

    void Update()
    {
        karmaAmount = playerStats.karmaAmount;
        Debug.Log(karmaAmount);
        karmaEvilGauge.fillAmount = Mathf.SmoothDamp(karmaEvilGauge.fillAmount, Mathf.Clamp01(karmaAmount), ref DecreaseVel, 0.3f);
        karmaGoodGauge.fillAmount = Mathf.SmoothDamp(karmaGoodGauge.fillAmount, Mathf.Clamp01(karmaAmount), ref DecreaseVel, 0.3f);	
    }
}
