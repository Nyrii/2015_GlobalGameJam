using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Karma : MonoBehaviour {

    public static float karmaAmount = 0.5f;
    float DecreaseVel;
    private Image karmaBar;
    private Image karmaBarExtern;
    _GameManager gm;

    void Start()
    {
        gm = GameObject.Find("_GameManager").GetComponent<_GameManager>();
        karmaBar = GetComponent<Image>();
    }

    void Update()
    {
        karmaBar.fillAmount = Mathf.SmoothDamp(karmaBar.fillAmount, Mathf.Clamp01(karmaAmount), ref DecreaseVel, 0.3f);	
    }
}
