using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float score = 0;

    public Text scoreText;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
