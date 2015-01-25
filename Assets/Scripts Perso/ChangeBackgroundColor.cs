using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class ChangeBackgroundColor : MonoBehaviour {

    PlatformerCharacter2D playerData;
    public SpriteRenderer blueBG;
    public SpriteRenderer redBG;
    float karmaAmount;

    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();
    }

    void Update()
    {
        if (playerData == null)
        {
            playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();
            return;
        }
        karmaAmount = playerData.karmaAmount;
        Debug.Log("KARMA = " + karmaAmount);
        redBG.color = new Color(1, 1, 1, Mathf.Clamp01(1 - 2 * karmaAmount));
        blueBG.color = new Color(1, 1, 1, Mathf.Clamp01(2 * karmaAmount - 1f));
    }
}
