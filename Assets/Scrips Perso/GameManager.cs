using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public void LoadLevel(int level)
    {
        if (level == -1)
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(level);
        }
    }
}
