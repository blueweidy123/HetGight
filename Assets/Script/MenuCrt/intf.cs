using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intf : MonoBehaviour
{
    public Text HighScore;

    // Update is called once per frame
    void Update()
    {
        float HS = PlayerPrefs.GetFloat("HighScore");
        HighScore.text = HS.ToString("0");
    }
}
