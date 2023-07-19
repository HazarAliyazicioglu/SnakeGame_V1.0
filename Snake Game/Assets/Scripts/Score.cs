using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public Text scoreText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score:" + score.ToString();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Score:" + score.ToString();
    }

    public void ResetPoint()
    {
        score = 0;
        scoreText.text = "Score:" + score.ToString();
    }


}
