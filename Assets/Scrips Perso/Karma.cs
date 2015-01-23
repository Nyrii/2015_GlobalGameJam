using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Karma : MonoBehaviour {

    public float karmaAmount = 0;
    float DecreaseVel;
    public Image karmaBar;
    public Image karmaBarExtern;
    _GameManager gm;

    void Start()
    {
        gm = GameObject.Find("_GameManager").GetComponent<_GameManager>();
    }

    void Update()
    {
        karmaBar.fillAmount = Mathf.SmoothDamp(karmaBar.fillAmount, karmaAmount, ref DecreaseVel, 0.3f);	
    }
}
