using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreManager : MonoBehaviour
{
    public int Score;
    private TMP_Text scoreDisplay;
    public static ScoreManager Singleton;

    void Start()
    {
        scoreDisplay = GetComponent<TMP_Text>();
        Score = 0;
        Singleton = this;
    }

    public static void AddScore(int delta)
    {
        SoundManager.PlaySound("coin");
        Singleton.AddScoreInternal(delta);
    }

    private void AddScoreInternal(int delta)
    {
        Score += delta;
        scoreDisplay.text = "Score " + Score.ToString();
    }
}
