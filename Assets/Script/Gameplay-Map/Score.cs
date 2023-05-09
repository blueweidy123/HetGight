using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoretext;
    public float lower;
    public float record = 0f;
    public float score;
    public Transform players;
    private bool saveable;

    // Update is called once per frame
    void Update()
    {
        lower = players.transform.position.y;
        if(lower > record)
        {
            record = lower;
            score = record;
            saveable = true;
        }
        scoretext.text = "SCORE: " + score.ToString("0");
        if (saveable)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
