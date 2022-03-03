using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculater : MonoBehaviour
{
    public static ScoreCalculater scoreCalculater;

    public int Score;
    public int blockCount;
    public int nameCount;

    public Text scoreText;

    private void Awake()
    {
        scoreCalculater = this;
    }

    public void ScoreCalculator()
    {
        Score = nameCount * blockCount;
        scoreText.text = Score.ToString();
    }
}
